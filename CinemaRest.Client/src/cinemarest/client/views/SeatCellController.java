package cinemarest.client.views;

import cinemarest.client.models.Seat;
import javafx.css.PseudoClass;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Label;
import javafx.scene.control.ListCell;
import javafx.scene.layout.AnchorPane;

import java.io.IOException;

public class SeatCellController extends ListCell<Seat> {
    private FXMLLoader mLLoader;
    @FXML
    private Label seatInfo;
    @FXML
    private AnchorPane anchorPane;

    @Override
    protected void updateItem(Seat seat, boolean empty) {
        super.updateItem(seat, empty);
        PseudoClass FAVORITE_PSEUDO_CLASS = PseudoClass.getPseudoClass("favorite");
        if(empty || seat == null)
        {
            setText(null);
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, false);
        } else {
            if(mLLoader == null) {
                try {
                    mLLoader = new FXMLLoader(getClass().getResource("SeatCell.fxml"));
                    mLLoader.setController(this);
                    mLLoader.load();
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, !isSelected());
            seatInfo.setText("Rząd " + seat.getRow() + ", Miejsce " + seat.getSeatNumber());
            setText(null);
            setGraphic(anchorPane);
        }
    }
}
