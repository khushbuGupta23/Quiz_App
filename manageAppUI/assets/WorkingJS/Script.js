

var app = angular.module('homeapp', ['ui.bootstrap', 'ngLoadingSpinner', 'angularUtils.directives.dirPagination', 'ngAnimate',
    'ngRoute', 'angular.morris-chart', 'LoginModule', 'QuestionModule', 'Subjectmodule', 'roleModule', 'UserModule', 'levelModule',
    'LoginModule', 'ResultModule']);

app.factory('httpRequestInterceptor', function () {
    return {
        request: function (config) {
            var session = angular.fromJson(sessionStorage.getItem("app")) || angular.fromJson(sessionStorage.getItem("app")).Role_Id;
            console.log(session);
            if (session != null) {
                return config;
            }
            sessionStorage.setItem("app", null);
            return;
        },

        responseError: function (response) {
            if (response.status === 403 || response.status === 400) {
                var data = {};
                sessionStorage.setItem("app", null);
            }
        }
    };
});



app.config(function ($routeProvider, $httpProvider, $locationProvider) {
    $routeProvider
       
        .when("/Login", {
            templateUrl: "Login.html",
            controller: "LoginController"
        }) .when("/Role", {
            templateUrl: "assets/HTML/RoleMaster.html",
            controller: "appController"
        })
        .when("/Subject", {
            templateUrl: "assets/HTML/SubjectManage.html",
            controller: "SubjectController"
        })
        .when("/Users", {
            templateUrl: "assets/HTML/MangeUser.html",
            controller: "UserController"
        })
        .when("/Question", {
            templateUrl: "assets/HTML/QuestionBank.html",
            controller: "QuestionBankController"
        })
        .when("/Levels", {
            templateUrl: "assets/HTML/Levels.html",
            controller: "LevelController"
        })

        .when("/Result", {
            templateUrl: "assets/HTML/Result.html",
            controller: "ResultController"
        })
        //.when("/SignUp", {
        //    templateUrl: "assets/HTML/SignUp.html",
        //    controller: "SignUpController"
        //})
       
        .otherwise({
            redirectTo: "/"
        });

    $locationProvider.hashPrefix('');
    $httpProvider.interceptors.push('httpRequestInterceptor');


});
app.service('HomeService', function ($http, $location) {

    this.AppUrl = "";

    console.log($location.absUrl());

    if ($location.absUrl().indexOf('CST') !== -1) {
        this.AppUrl = "/CST/api/";
    }
    else {
        this.AppUrl = "/api/";
    }


});
app.filter('reverse', function () {
    return function (items) {
        return items.slice().reverse();
    };
});
   
app.controller('homeController', function ($scope, HomeService, $http, $rootScope, $window, $location) {
    


    $scope.init = function () {
        $rootScope.session = angular.fromJson(sessionStorage.getItem("app"));
    };
});

