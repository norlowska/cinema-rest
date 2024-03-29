package cinemarest.client.service;

import cinemarest.client.Main;
import cinemarest.client.RequestInterceptor;
import cinemarest.client.models.*;
import cinemarest.client.views.RepertoireController;
import com.google.gson.*;
import com.google.gson.reflect.TypeToken;
import okhttp3.*;
import org.jetbrains.annotations.Nullable;
import sun.misc.BASE64Encoder;

import javax.xml.ws.BindingProvider;
import javax.xml.ws.handler.MessageContext;
import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.*;

public class CinemaRestService implements ICinemaService {
    public static final MediaType JSON = MediaType.parse("application/json; charset=utf-8");
    Gson gson;
    OkHttpClient.Builder httpClient;

    public CinemaRestService() {
        gson = new GsonBuilder().setLenient().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
        httpClient = new OkHttpClient.Builder();
        httpClient.addInterceptor(new RequestInterceptor());
    }

    @Override
    public List<Movie> getRepertoire(String date) {
        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url("https://localhost:44318/api/Movie?date=" + date)
                .method("GET", null)
                .build();
        try(Response response = client.newCall(request).execute()) {
            Type listOfMyClassObject = new TypeToken<ArrayList<Movie>>() {}.getType();

            return gson.fromJson(response.body().string(), listOfMyClassObject);
        }
        catch(Exception ex) {
            ex.printStackTrace();
            return null;
        }
    }

    @Override
    public byte[] getPoster(Movie movie) {
        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url(movie.getLinks().stream().filter(i -> i.getRel().equals("get_poster")).findFirst().orElse(new Link("https://localhost:44318/api/Movie/" + movie.getId() + "/Poster")).getHref())
                .method("GET", null)
                .build();
        try(Response response = client.newCall(request).execute()) {
            return  response.body().bytes();
        }
        catch(Exception ex) {
            ex.printStackTrace();
        }
        return null;
    }

    @Override
    public JsonObject bookScreening(Reservation reservation, String email) {
        OkHttpClient client = httpClient.build();

        MakeReservationRequest dto = new MakeReservationRequest();
        dto.setScreeningId(reservation.getScreening().getId());
        dto.setSeats(reservation.getSeats());
        String data = gson.toJson(dto);
        RequestBody body = RequestBody.create(data, JSON);

        Request request = new Request.Builder()
                .url(reservation.getLinks().stream().filter(i -> i.getRel().equals("create_reservation")).findFirst().orElse(new Link("https://localhost:44318/api/Reservation/")).getHref())
                .method("POST", body)
                .build();

        return getReservationResponseJsonObject(client, request);
    }

    @Override
    public JsonObject editReservation(Reservation reservation) {
        OkHttpClient client = httpClient.build();

        String data = gson.toJson(reservation.getSeats());
        RequestBody body = RequestBody.create(data, JSON);

        Request request = new Request.Builder()
                .url(reservation.getLinks().stream().filter(i -> i.getRel().equals("update_reservation")).findFirst().orElse(new Link("https://localhost:44318/api/Reservation/" + reservation.getId())).getHref())
                .method("PUT", body)
                .build();
        return getReservationResponseJsonObject(client, request);
    }

    @Override
    public JsonPrimitive signIn(String email, String password) {
        String authString = email + ":" + password;
        String authStringEnc = new BASE64Encoder().encode(authString.getBytes());
        Main.setAuthHeaderValue(authStringEnc);

        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url("https://localhost:44318/api/User/Login")
                .method("POST", RequestBody.create(null, new byte[]{}))
                .build();

        try(Response response = client.newCall(request).execute()) {
            if(response.code() > 300) return new JsonPrimitive(response.body().string());
            Main.setUserEmail(email);
            return new JsonPrimitive(Boolean.parseBoolean(response.body().string()));
        }
        catch(Exception ex) {
            ex.printStackTrace();
        }
        return null;
    }

    @Override
    public List<Reservation> getReservationList(String email)
    {
        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url("https://localhost:44318/api/Reservation?email=" + email)
                .method("GET", null)
                .build();
        try(Response response = client.newCall(request).execute()) {
            Type listOfMyClassObject = new TypeToken<ArrayList<Reservation>>() {}.getType();
            String ss = response.body().string();
            return gson.fromJson(ss, listOfMyClassObject);
        }
        catch(Exception ex) {
            ex.printStackTrace();
            return null;
        }
    }

    @Nullable
    private JsonObject getReservationResponseJsonObject(OkHttpClient client, Request request) {
        try(Response response = client.newCall(request).execute()) {
            if(response.code() != 200) return gson.fromJson(response.body().string(), JsonObject.class);
            byte[] byteArr = response.body().bytes();
            Headers headers = response.headers();

            String ss = gson.toJson(byteArr);
            JsonObject jo = new JsonObject();
            jo.add("data", JsonParser.parseString(ss));
            jo.add("status", JsonParser.parseString(String.valueOf(response.code())));
            String disposition =headers.get("content-disposition");
            String fileName = disposition.replaceFirst("(?i)^.*filename\\*=UTF-8[\"\']{0,2}([^\"]+)\"?.*$", "$1");
            jo.add("filename", JsonParser.parseString(fileName));
            return  jo;
        }
        catch(Exception ex) {
            ex.printStackTrace();
        }
        return null;
    }

    @Override
    public boolean cancelReservation(Reservation reservation) {
        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url(reservation.getLinks().stream().filter(i -> i.getRel().equals("delete_reservation")).findFirst().orElse(new Link("https://localhost:44318/api/Reservation/" + reservation.getId())).getHref())
                .method("DELETE", null)
                .build();
        try(Response response = client.newCall(request).execute()) {
            return gson.fromJson(response.body().string(), boolean.class);
        }
        catch(Exception ex) {
            ex.printStackTrace();
        }
        return false;
    }
}
