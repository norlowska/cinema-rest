package cinemarest.client.views;


import java.io.IOException;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.*;

import cinemarest.client.Main;
import cinemarest.client.service.CinemaRestService;
import cinemarest.client.service.ICinemaService;
import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonPrimitive;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.stage.Stage;
import javafx.util.Callback;
import sun.misc.BASE64Encoder;

import javax.xml.ws.BindingProvider;
import javax.xml.ws.handler.MessageContext;
import javax.xml.ws.soap.AddressingFeature;

public class LoginScreenController implements Initializable {
    @FXML
    private TextField emailTextBox;
    @FXML
    private PasswordField passwordTextBox;
    @FXML
    private Button loginButton;

    public ICinemaService service;
    public String[] loginData;
    FXMLLoader loader;

    public LoginScreenController() {
        service = new CinemaRestService();
    }

    private void getLoginData()
    {
        loginData = new String[2];

        loginData[0] = this.emailTextBox.getText();
        loginData[1] = this.passwordTextBox.getText();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    loginButton.setOnAction(new EventHandler<ActionEvent>() {
        @Override
        public void handle(ActionEvent event) {
            try {
                getLoginData();
                final Stage thisStage = (Stage)loginButton.getScene().getWindow();
                loader = new FXMLLoader(getClass().getResource("Repertoire.fxml"));

                try {
                    JsonPrimitive result =service.signIn(loginData[0], loginData[1]);
                    if(result.isString()) {
                        JsonPrimitive primitive = result.getAsJsonPrimitive();
                        Alert alert = new Alert(Alert.AlertType.ERROR);
                        alert.setContentText(primitive.getAsString());
                        alert.show();
                        Main.setAuthHeaderValue("");
                        Main.setUserEmail("");
                        return;
                    }
                } catch (Exception ex) {
                    Alert alert = new Alert(Alert.AlertType.ERROR);
                    alert.setContentText("Wystąpił błąd podczas logowania");
                    alert.show();
                    Main.setAuthHeaderValue("");
                    Main.setUserEmail("");
                    return;
                }
                Parent root = (Parent) loader.load();
                Stage repertoireStage = new Stage();
                repertoireStage.setScene(new Scene(root));
                repertoireStage.setTitle("Repertuar | Cinema SOAP");
                thisStage.close();
                repertoireStage.show();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    });
    }
}
