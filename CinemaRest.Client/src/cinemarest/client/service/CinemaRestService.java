package cinemarest.client.service;

import cinemarest.client.models.Movie;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import okhttp3.*;
import okio.Buffer;
import okio.BufferedSink;
import okio.BufferedSource;
import okio.Okio;
import org.omg.CORBA.portable.OutputStream;
import sun.misc.IOUtils;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.lang.reflect.Type;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

public class CinemaRestService implements ICinemaService {
    Gson gson;
    public CinemaRestService() {
        gson = new GsonBuilder().setLenient().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
    }

    @Override
    public List<Movie> getRepertoire(String date) {
        OkHttpClient client = new OkHttpClient().newBuilder()
                .build();
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
        OkHttpClient client = new OkHttpClient().newBuilder()
                .build();
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
}
