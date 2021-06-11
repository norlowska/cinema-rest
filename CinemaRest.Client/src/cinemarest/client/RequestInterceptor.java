package cinemarest.client;

import javafx.util.Pair;
import okhttp3.Interceptor;
import okhttp3.Request;
import okhttp3.Response;
import org.jetbrains.annotations.NotNull;
import sun.rmi.runtime.Log;

import java.io.IOException;

public class RequestInterceptor implements Interceptor {
    private final String AUTHORIZATION_HEADER = "Authorization";
    private final String AUTHORIZATION_TYPE = "Basic ";
    @NotNull
    @Override
    public Response intercept(@NotNull Chain chain) throws IOException {
        Request request = chain.request();
        Request newRequest;

        try {
            String authHeaderValue = Main.getAuthHeaderValue();
            if(authHeaderValue != null && !authHeaderValue.isEmpty()) {
                newRequest = request.newBuilder()
                        .addHeader(AUTHORIZATION_HEADER, AUTHORIZATION_TYPE + authHeaderValue)
                        .build();
                return chain.proceed(newRequest);
            }
        } catch (Exception e) {
            e.printStackTrace();
            return chain.proceed(request);
        }

        return chain.proceed(request);
    }
}
