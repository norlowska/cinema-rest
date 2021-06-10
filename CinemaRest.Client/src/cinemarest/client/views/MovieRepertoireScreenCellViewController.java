package cinemarest.client.views;

import cinemarest.client.models.Screening;
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

import java.io.IOException;
import java.text.SimpleDateFormat;

public class MovieRepertoireScreenCellViewController extends ListCell<Screening> {

    private FXMLLoader mLLoader;

    @FXML
    public AnchorPane screeningCell;
    @FXML
    public Button bookButton;
    @FXML
    public Label timeLabel;

    @Override
    protected void updateItem(Screening screening, boolean empty) {
        super.updateItem(screening, empty);
        PseudoClass FAVORITE_PSEUDO_CLASS = PseudoClass.getPseudoClass("favorite");
        if(empty || screening == null)
        {
            setText(null);
            setGraphic(null);
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, false);
        } else {
            if(mLLoader == null) {
                try {
                    mLLoader = new FXMLLoader(getClass().getResource("MovieRepertoireScreenCellView.fxml"));
                    mLLoader.setController(this);
                    mLLoader.load();
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, !isSelected());
            SimpleDateFormat formatter = new SimpleDateFormat("HH:mm dd.MM.yyyy");
            timeLabel.setText("Czas: " + formatter.format(screening.getFullDate()));
            bookButton.setOnMouseClicked(new EventHandler<MouseEvent>() {
                public void handle(MouseEvent event) {
                    if (screening != null) {
                        try {
                            FXMLLoader loader = new FXMLLoader(getClass().getResource("ReservationScreen.fxml"));
                            loader.setController(new ReservationScreenController(screening, false));
                            Scene sc = new Scene(loader.load(), 600, 400);
                            Stage stage = new Stage();
                            stage.setScene(sc);
                            stage.setTitle("Rezerwacja miejsc | Cinema SOAP");

                            stage.show();
                            final Stage thisStage = (Stage)bookButton.getScene().getWindow();
                            thisStage.close();
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    } else {

                    }
                }
            });
            setGraphic(screeningCell);
        }
    }
}
