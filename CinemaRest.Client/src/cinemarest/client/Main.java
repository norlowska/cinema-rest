package cinemarest.client;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import javafx.util.Pair;

import java.util.List;

public class Main extends Application {
    private static String authHeaderValue;
    public static String getAuthHeaderValue() {
        return authHeaderValue;
    }
    public static void setAuthHeaderValue(String value) {
        Main.authHeaderValue = value;
    }


    private  static String userEmail;
    public static String getUserEmail() {
        return userEmail;
    }
    public static void setUserEmail(String userEmail) {
        Main.userEmail = userEmail;
    }

    @Override
    public void start(Stage primaryStage) throws Exception{
        try {
            Parent root = FXMLLoader.load(getClass().getResource("views/LoginScreen.fxml"));
            primaryStage.setTitle("Logowanie | Cinema SOAP");
            Scene sc = new Scene(root, 600, 400);
            sc.getStylesheets().add(this.getClass().getResource("styles.css").toExternalForm());
            primaryStage.setScene(sc);
            primaryStage.show();
        } catch(Exception e) {
            e.printStackTrace();
        }
    }


    public static void main(String[] args) {
        launch(args);
    }
}
