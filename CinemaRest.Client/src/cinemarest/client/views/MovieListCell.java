package cinemarest.client.views;

import cinemarest.client.models.Actor;
import cinemarest.client.models.CrewMember;
import cinemarest.client.models.Movie;
import cinemarest.client.models.Character;
import cinemarest.client.service.CinemaRestService;
import cinemarest.client.service.ICinemaService;
import javafx.css.PseudoClass;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.control.Label;
import javafx.scene.control.ListCell;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;
import javafx.scene.text.Text;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.util.List;

public class MovieListCell extends ListCell<Movie> {
    private FXMLLoader mLLoader;
    @FXML
    private AnchorPane anchorPane;
    @FXML
    private Text title;
    @FXML
    private Text director;
    @FXML
    private Label description;
    @FXML
    private Label cast;
    @FXML
    private ImageView poster;

    @Override
    protected void updateItem(Movie movie, boolean empty) {
        super.updateItem(movie, empty);
        PseudoClass FAVORITE_PSEUDO_CLASS = PseudoClass.getPseudoClass("favorite");
        if(empty || movie == null)
        {
            setText(null);
            setGraphic(null);
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, false);
        } else {
            if(mLLoader == null) {
                try {
                    mLLoader = new FXMLLoader(getClass().getResource("MovieListCellView.fxml"));
                    mLLoader.setController(this);
                    mLLoader.load();
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
            pseudoClassStateChanged(FAVORITE_PSEUDO_CLASS, !isSelected());
            title.setText(movie.getTitle());
            List<CrewMember> crewMemberList = movie.getCrew();
            String directorStr = "reż. ";
            for(CrewMember cm : crewMemberList){
                if(cm.getJob().equals("Director"))
                    directorStr += cm.getFirstName() +" "+ cm.getLastName() + ", ";
            };
            director.setText(directorStr.substring(0, directorStr.length()-2));
            description.setText(movie.getDescription());
            String castStr = "";
            for(Character item : movie.getCharacters()){
                Actor actor = item.getActor();
                castStr += actor.getFirstName() + " " + (actor.getSecondName() != null && !actor.getSecondName().isEmpty() ? actor.getSecondName() + " " : "") + actor.getLastName() + ", ";
            }
            castStr =  castStr.substring(0, castStr.length() -2);
            cast.setText(castStr);
            ICinemaService service = new CinemaRestService();
            poster.setImage(new Image(new ByteArrayInputStream((service.getPoster(movie.getId())))));
            setText(null);
            setGraphic(anchorPane);
        }
    }
}
