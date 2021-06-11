package cinemarest.client.service;

import cinemarest.client.Main;
import cinemarest.client.RequestInterceptor;
import cinemarest.client.models.MakeReservationRequest;
import cinemarest.client.models.Movie;
import cinemarest.client.models.Reservation;
import cinemarest.client.models.Seat;
import cinemarest.client.views.RepertoireController;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
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
    public byte[] getPoster(String id) {
        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url("https://localhost:44318/api/Movie/" + id + "/Poster")
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
    public JsonObject bookScreening(String id, List<Seat> seats, String email) {
        OkHttpClient client = httpClient.build();

        MakeReservationRequest dto = new MakeReservationRequest();
        dto.setScreeningId(id);
        dto.setSeats(seats);
        String data = gson.toJson(dto);
        RequestBody body = RequestBody.create(data, JSON);

        Request request = new Request.Builder()
                .url("https://localhost:44318/api/Reservation/")
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
                .url("https://localhost:44318/api/Reservation/" + reservation.getId())
                .method("PUT", null)
                .build();
        return getReservationResponseJsonObject(client, request);
    }

    @Override
    public JsonObject signIn(String email, String password) {
        String authString = email + ":" + password;
        String authStringEnc = new BASE64Encoder().encode(authString.getBytes());
        Main.setAuthHeaderValue(authStringEnc);

        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url("https://localhost:44318/api/User/Login")
                .method("POST", RequestBody.create(null, new byte[]{}))
                .build();

        try(Response response = client.newCall(request).execute()) {
            if(response.code() == 500) return gson.fromJson(response.body().string(), JsonObject.class);
            if(response.code() != 200) return gson.fromJson(response.body().string(), JsonObject.class);
            Main.setUserEmail(email);
            return null;
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
    public boolean cancelReservation(String id) {
        OkHttpClient client = httpClient.build();
        Request request = new Request.Builder()
                .url("https://localhost:44318/api/Reservation/" + id)
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
