package cinemarest.client.models;

import java.util.ArrayList;
import java.util.List;

public class Movie {
    private String id;
    private String title;
    private String description;
    private boolean deleted;
    private List<CrewMember> crew;
    private List<Character> characters;
    private List<Screening> screenings;
    private List<Link> links = new ArrayList<Link>();

    public List<Link> getLinks() {
        return links;
    }

    public void setLinks(List<Link> links) {
        this.links = links;
    }

    public String getId()
    {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTitle()
    {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public boolean isDeleted() {
        return deleted;
    }

    public void setDeleted(boolean deleted) {
        this.deleted = deleted;
    }

    public List<CrewMember> getCrew() {
        return crew;
    }

    public void setCrew(List<CrewMember> crew) {
        this.crew = crew;
    }

    public List<Character> getCharacters() {
        return characters;
    }

    public void setCharacters(List<Character> characters) {
        this.characters = characters;
    }

    public List<Screening> getScreenings() {
        return screenings;
    }

    public void setScreenings(List<Screening> screenings) {
        this.screenings = screenings;
    }
}
