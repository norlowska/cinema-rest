package cinemarest.client.views;

import cinemarest.client.Main;
import cinemarest.client.models.Movie;
import cinemarest.client.models.Reservation;
import cinemarest.client.models.Screening;
import cinemarest.client.models.Seat;
import cinemarest.client.service.CinemaRestService;
import cinemarest.client.service.ICinemaService;
import com.google.gson.Gson;
import com.google.gson.JsonObject;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.nio.file.Files;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class ReservationScreenController implements Initializable {

    private ICinemaService service;
    private ObservableList<Seat> seats;
    private Screening screening;
    private Reservation reservation;
    private boolean isEdit;

    private Movie movie;

    @FXML
    private Label infoLabel;

    @FXML
    private ImageView posterView;

    @FXML
    private Button bookButton;

    @FXML
    private Button cancelButton;

    @FXML
    private ListView seatsView;



    public ReservationScreenController(Screening screening, boolean isEdit)
    {
        this.screening = screening;
        this.movie = screening.getMovie();
        this.isEdit = isEdit;
        service = new CinemaRestService();
        seats = FXCollections.observableArrayList();
        seats.addAll(screening.getFreeSeats());
    }

    public ReservationScreenController(Reservation reservation, boolean isEdit)
    {
        service = new CinemaRestService();
        this.reservation = reservation;
        this.movie = reservation.getScreening().getMovie();
        SimpleDateFormat formatter = new SimpleDateFormat("yyyy.MM.dd");
        this.screening = service
                .getRepertoire(formatter.format(reservation.getScreening().getFullDate()))
                .stream()
                .filter(i -> i.getId().equals(reservation.getScreening().getMovie().getId()))
                .findFirst().orElse(null)
                .getScreenings()
                .stream()
                .filter(i -> i.getFullDate().equals(reservation.getScreening().getFullDate()))
                .findFirst().orElse(null);
        this.isEdit = isEdit;
        seats = FXCollections.observableArrayList();
        List<Seat> seatsList = screening.getFreeSeats();
        for(Seat s : reservation.getSeats()) {
            if(!seatsList.stream().anyMatch(i -> i.getId().equals(s.getId())))
                seatsList.add(s);
        }
        Comparator<Seat> comparator = Comparator.comparing(seat -> seat.getRow());
        comparator = comparator.thenComparing(seat -> seat.getSeatNumber());
        Stream<Seat> seatStream = seatsList.stream().sorted(comparator);
        seats.addAll(seatStream.collect(Collectors.toList()));
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        SimpleDateFormat formatter = new SimpleDateFormat("dd.MM.yyyy HH:mm");
        infoLabel.setText("Tytuł: " + movie.getTitle() +
                "\nData: " + formatter.format(screening.getFullDate()) +
                "\nSala: " + screening.getScreen().getName());
        posterView.setImage(new Image(new ByteArrayInputStream(service.getPoster(movie.getId()))));
        seatsView.getSelectionModel().setSelectionMode(SelectionMode.MULTIPLE);
        seatsView.setItems(seats);
        seatsView.setCellFactory(seatsView -> new SeatCellController());

        cancelButton.setOnMouseClicked(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent event) {
                final Stage thisStage = (Stage)cancelButton.getScene().getWindow();
                thisStage.close();
            }
        });

        bookButton.setOnMouseClicked(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent event) {
                List<Seat> selectedIndices = seatsView.getSelectionModel().getSelectedItems();
                List<Seat> seats = new ArrayList<>();
                seats.addAll(selectedIndices);
                JsonObject res;
                if(isEdit) {
                    Reservation newReservation = reservation;
                    newReservation.setSeats(seats);
                    res = service.editReservation(newReservation);
                }
                else {
                     res = service.bookScreening(screening.getId(), seats, Main.getUserEmail());
                }

                if(Integer.parseInt(res.get("status").getAsString()) > 300) {
                    Alert errorAlert = new Alert(Alert.AlertType.ERROR);
                    errorAlert.setContentText(res.get("detail").getAsString());
                    errorAlert.show();
                    return;
                }
                final Stage thisStage = (Stage)cancelButton.getScene().getWindow();
                FileChooser fileChooser = new FileChooser();
                fileChooser.setTitle("Zapisz potwierdzenie");
                fileChooser.setInitialFileName(res.get("filename").getAsString());
                fileChooser.setInitialDirectory(new File(System.getProperty("user.home")));
                fileChooser.getExtensionFilters().add(new FileChooser.ExtensionFilter("PDF", "*.pdf"));
                File file = fileChooser.showSaveDialog(thisStage);
                if (file != null) {
                    try {
                        Gson gson = new Gson();
                        Files.write(file.toPath(), gson.fromJson(res.get("data"), byte[].class));
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
                thisStage.close();
            }
        });
    }


}
