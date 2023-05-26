var app = angular.module("UserHomeModule", ['ngRoute', 'levelModule', 'QuestionModule', 'ResultModule']);


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

        .when('/Question/', {
            templateUrl: "HTML/QuestionBank.html",
            controller: "QuestionBankController"
        })
        .when('/Levels/', {
            templateUrl: "HTML/Levels.html",
            controller: "LevelController"
        })

        .when('/Result/', {
            templateUrl: "HTML/Result.html",
            controller: "ResultController"
        })

        .otherwise({
            redirectTo: "/"
        });

    $locationProvider.hashPrefix('');
    $httpProvider.interceptors.push('httpRequestInterceptor');


});
app.service('UserhomeService', function ($http, $location) { 
    this.AppUrl = "/api/";
    this.SubjectList = function () {

        return $http.get(this.AppUrl + 'Subject/GetList');
    }
    this.ChkUserTestResult = function (Subject_Id, UserName) {
        return $http.get(this.AppUrl + 'Subject/GetLists?Subject_Id=' + Subject_Id + '&UserName=' + UserName);
    }


});



app.controller('UserHomeController', function ($scope, UserhomeService, $rootScope, $location) {
   
    $scope.showHome = false;
    $scope.showView = true;
    $scope.showBack = true;
    $scope.isDisabled = true;
    $scope.showResult = true;
    $scope.init = function () {

        UserhomeService.SubjectList().then(function (success) {
            $scope.ProgramArray = success.data;
        });
       
    };
    $scope.ViewButton = function (Subject_Id) {
        debugger;
        UserhomeService.Subject_Id = Subject_Id;
        $rootScope.SubjectId = Subject_Id;
        console.log("RootCheck", $rootScope.SubjectId);
        $scope.UserName = angular.fromJson(sessionStorage.getItem("app")).UserName;
        UserhomeService.ChkUserTestResult(Subject_Id, $scope.UserName).then(function (success) {
            $scope.recordList = success.data;
          
                if ($scope.recordList[0].TestCode == true) {
                    $scope.showHome = true;
                    $scope.showView = false;
                    $scope.showResult = true;
                    $scope.isDisabled = false;
                }
                else {
                    swal("You have already attemped !");
                    $scope.showHome = false;
                    $scope.showView = true;
                    $scope.isDisabled = true;
                    $scope.showResult = true;
                }
           

        });
    };
    $scope.ClickButton= function (Subject_Id) {
       
        $scope.showHome = false;

        $location.path("/Levels");
        //window.location.href = 'HTMl/Levels.html';
    };

    $scope.ClickBtn = function () {

        $scope.showView = false;
        $scope.showHome = false;

        $location.path("/Result");
        //window.location.href = 'HTML/Result.html';
    }
    
    $scope.Back = function () {
        window.location.href = '/UserHome.html';
        $scope.showBack = false;
       
    };
    $scope.login = function () {

        console.log("Clicked");
        window.location.href = '/Login.html';
    };
    $scope.init();
})