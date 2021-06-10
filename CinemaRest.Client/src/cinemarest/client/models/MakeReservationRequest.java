package cinemarest.client.models;

import java.util.List;

public class MakeReservationRequest {
    private String ScreeningId;
    private List<Seat> Seats;

    public String getScreeningId() {
        return ScreeningId;
    }

    public void setScreeningId(String screeningId) {
        ScreeningId = screeningId;
    }

    public List<Seat> getSeats() {
        return Seats;
    }

    public void setSeats(List<Seat> seats) {
        Seats = seats;
    }
}
