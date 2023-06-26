package com.api.server.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelpController {

    @GetMapping("/help")
    public String GetHelp() {
        return "Help";
    }
}
