package cinemarest.client.service;

import cinemarest.client.models.Movie;

import java.io.InputStream;
import java.util.Date;
import java.util.List;

public interface ICinemaService {
    public List<Movie> getRepertoire(String date);
    public byte[] getPoster(String id);

}
