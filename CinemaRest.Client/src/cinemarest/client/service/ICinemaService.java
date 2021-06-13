package cinemarest.client.service;

import cinemarest.client.models.Movie;
import cinemarest.client.models.Reservation;
import cinemarest.client.models.Seat;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonPrimitive;

import java.io.InputStream;
import java.util.Date;
import java.util.List;

public interface ICinemaService {
    public List<Movie> getRepertoire(String date);
    public byte[] getPoster(Movie movie);
    public JsonObject bookScreening(Reservation reservation, String email);
    public JsonObject editReservation(Reservation reservation);
    public JsonPrimitive signIn(String email, String password);
    public List<Reservation> getReservationList(String email);
    public boolean cancelReservation(Reservation reservation);
}
