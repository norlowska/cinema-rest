package cinemarest.client.service;

import cinemarest.client.models.Movie;
import cinemarest.client.models.Reservation;
import cinemarest.client.models.Seat;
import com.google.gson.JsonObject;

import java.io.InputStream;
import java.util.Date;
import java.util.List;

public interface ICinemaService {
    public List<Movie> getRepertoire(String date);
    public byte[] getPoster(String id);
    public JsonObject bookScreening(String id, List<Seat> seats, String email);
    public JsonObject editReservation(Reservation reservation);
    public List<Reservation> getReservationList(String email);
}
