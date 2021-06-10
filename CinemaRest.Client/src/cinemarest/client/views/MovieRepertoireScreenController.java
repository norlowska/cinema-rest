package cinemarest.client.views;

import cinemarest.client.models.Screening;
import cinemarest.client.service.CinemaRestService;
import cinemarest.client.service.ICinemaService;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.input.MouseEvent;
import javafx.stage.Stage;

import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;

public class MovieRepertoireScreenController implements Initializable {
    private ObservableList<Screening> screenings;
    private ICinemaService service;

    @FXML
    private ListView seancesList;
    @FXML
    private Button cancelBtn;

    public MovieRepertoireScreenController(List<Screening> screeningsList)
    {
        service = new CinemaRestService();
        screenings = FXCollections.observableArrayList();
        screenings.addAll(screeningsList);
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        seancesList.setItems(screenings);
        seancesList.setCellFactory(movieListView -> new MovieRepertoireScreenCellViewController());
        cancelBtn.setOnMouseClicked(new EventHandler<MouseEvent>() {
            public void handle(MouseEvent event) {
                final Stage thisStage = (Stage)cancelBtn.getScene().getWindow();
                thisStage.close();
            }
        });
    }
}
