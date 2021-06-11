package cinemarest.client.views;

import cinemarest.client.Main;
import cinemarest.client.models.Reservation;
import cinemarest.client.service.CinemaRestService;
import cinemarest.client.service.ICinemaService;
import javafx.beans.InvalidationListener;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.css.PseudoClass;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListCell;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;

import java.text.SimpleDateFormat;

public class ReservationCellController extends ListCell<Reservation> {
    private ICinemaService service;
    private FXMLLoader mLLoader;
    private Reservation reservation;

    @FXML
    Label titleInfo;
    @FXML
    Label screeningDetails;
    @FXML
    AnchorPane reservationCell;
    @FXML
    Button editReservation;
    @FXML
    Button cancelReservation;

    public ReservationCellController() {
        service = new CinemaRestService();
    }

    @FXML
    private void EditReservation()
    {

    }

    @Override
    protected void updateItem(Reservation reservation, boolean empty) {
        super.updateItem(reservation, empty);
        this.reservation = reservation;
        PseudoClass FAVORITE_PSEUDO_CLASS = PseudoClass.getPseudoClass("favorite");
        if(empty || reservation == null)
        {
            setText(null);
            setGraphic(null);
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, false);
        } else {
            try {
            if(mLLoader == null) {

                    mLLoader = new FXMLLoader(getClass().getResource("ReservationCell.fxml"));
                    mLLoader.setController(this);
                    mLLoader.load();

            }
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, !isSelected());
            SimpleDateFormat formatter = new SimpleDateFormat("HH:mm dd.MM.yyyy");
            titleInfo.setText(reservation.getScreening().getMovie().getTitle());
            screeningDetails.setText(formatter.format(reservation.getScreening().getFullDate()));
            editReservation.setOnMouseClicked(new EventHandler<MouseEvent>() {
                public void handle(MouseEvent event) {
                    if (reservation != null) {
                        try {
                            FXMLLoader loader = new FXMLLoader(getClass().getResource("ReservationScreen.fxml"));
                            loader.setController(new ReservationScreenController(reservation, true));
                            Scene sc = new Scene(loader.load(), 600, 400);
                            Stage stage = new Stage();
                            stage.setScene(sc);
                            stage.setOnHiding(new EventHandler<WindowEvent>() {
                              @Override
                              public void handle(WindowEvent event) {
                                  getListView().getItems().removeAll();
                                  getListView().setItems(FXCollections.observableArrayList(service.getReservationList(Main.getUserEmail())));
                              }
                          });
                            stage.setTitle("Edycja rezerwacji | Cinema SOAP");
                            stage.show();
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    } else {

                    }
                }
            });
            cancelReservation.setOnMouseClicked(new EventHandler<MouseEvent>() {
                public void handle(MouseEvent event) {
                    if (reservation != null) {
                        try {
                            //service.cancelReservation(reservation.getId());
                            getListView().getItems().remove(getItem());
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    } else {

                    }
                }
            });
                setGraphic(reservationCell);
            } catch (Exception ex) {
                ex.printStackTrace();
            }
        }
    }
}
