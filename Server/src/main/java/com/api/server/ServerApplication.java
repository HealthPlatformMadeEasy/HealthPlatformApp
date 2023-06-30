package com.api.server;

import com.api.server.services.DatabaseSeedService;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Profile;
import org.springframework.core.io.ClassPathResource;

import java.io.InputStream;

@SpringBootApplication
public class ServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(ServerApplication.class, args);
    }


    @Bean
    @Profile("development")
    CommandLineRunner runner(DatabaseSeedService seederService) {
        return args -> {
            InputStream inputStream = new ClassPathResource("database/seed/calories.csv").getInputStream();
            seederService.seedDatabaseFromCSVFile(inputStream);
        };
    }
}
