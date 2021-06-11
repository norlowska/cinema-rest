package cinemarest.client.views;

import cinemarest.client.Main;
import cinemarest.client.models.Reservation;
import cinemarest.client.models.Seat;
import cinemarest.client.service.CinemaRestService;
import cinemarest.client.service.ICinemaService;
import javafx.beans.binding.Bindings;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

import javax.xml.ws.Binding;
import javax.xml.ws.BindingProvider;
import javax.xml.ws.handler.MessageContext;
import javax.xml.ws.soap.AddressingFeature;
import java.net.URL;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.ResourceBundle;

public class AccountScreenController implements Initializable {
    public ObservableList<Reservation> reservations;
    private ICinemaService service;

    @FXML
    ListView reservationList;
    @FXML
    Button cancelBtn;

    public AccountScreenController()
    {
        service = new CinemaRestService();
        reservations = FXCollections.observableArrayList();
        reservations.addAll(service.getReservationList(Main.getUserEmail()));
    }

    @Override
    public void initialize(URL location, ResourceBundle resources)
    {
        reservationList.setItems(reservations);
        reservationList.setCellFactory(reservationCell -> new ReservationCellController());
        reservationList.setOnMouseClicked(new EventHandler<MouseEvent>() {
            @Override
            public void handle(MouseEvent click) {
                if (click.getClickCount() == 2) {
                    Reservation currentItemSelected = (Reservation) reservationList.getSelectionModel().getSelectedItem();
                    String seatsInfo = "";
                    for(Seat s : currentItemSelected.getSeats()) {
                        seatsInfo += "\nRząd " + s.getRow()  + ", Miejsce " + s.getSeatNumber();
                    }
                    Alert alert = new Alert(Alert.AlertType.INFORMATION, seatsInfo);
                    alert.setHeaderText("Zarezerowane miejsca");
                    alert.showAndWait();
                }
            }
        });
        cancelBtn.setOnMouseClicked(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent event) {
                final Stage thisStage = (Stage)cancelBtn.getScene().getWindow();
                thisStage.close();
            }
        });
    }


}
