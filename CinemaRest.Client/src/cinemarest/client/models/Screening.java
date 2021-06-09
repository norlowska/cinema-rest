package cinemarest.client.models;

import java.util.Date;
import java.util.List;

public class Screening {
    private String id;
    private Movie movie;
    private String date;
    private String time;
    private Date fullDate;
    private boolean deleted;
    private List<Seat> reservedSeats;
    private List<Seat> freeSeats;
    private Screen screen;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Movie getMovie() {
        return movie;
    }

    public void setMovie(Movie movie) {
        this.movie = movie;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public Date getFullDate() {
        return fullDate;
    }

    public void setFullDate(Date fullDate) {
        this.fullDate = fullDate;
    }

    public boolean isDeleted() {
        return deleted;
    }

    public void setDeleted(boolean deleted) {
        this.deleted = deleted;
    }

    public List<Seat> getReservedSeats() {
        return reservedSeats;
    }

    public void setReservedSeats(List<Seat> reservedSeats) {
        this.reservedSeats = reservedSeats;
    }

    public List<Seat> getFreeSeats() {
        return freeSeats;
    }

    public void setFreeSeats(List<Seat> freeSeats) {
        this.freeSeats = freeSeats;
    }

    public Screen getScreen() {
        return screen;
    }

    public void setScreen(Screen screen) {
        this.screen = screen;
    }
}
