var app = angular.module('AngularAuthApp',
['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ngGrid']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/dnn_webapi/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/dnn_webapi/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/dnn_webapi/app/views/signup.html"
    });

    $routeProvider.when("/log", {
        controller: "logController",
        templateUrl: "/dnn_webapi/app/views/mylogs.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});