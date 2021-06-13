package cinemarest.client.models;

public class Link {
    private String rel;
    private String href;
    private String method;

    public Link() {}

    public Link(String href) {
        this.href=href;
    }

    public String getRel() {
        return rel;
    }

    public void setRel(String rel) {
        this.rel = rel;
    }

    public String getHref() {
        return href;
    }

    public void setHref(String href) {
        this.href = href;
    }

    public String getMethod() {
        return method;
    }

    public void setMethod(String method) {
        this.method = method;
    }
}
