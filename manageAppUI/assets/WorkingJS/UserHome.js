var app = angular.module('UserHomeModule', ['homeapp']);

app.service('UserhomeService', function ($http, $location) { 
    this.AppUrl = "/api/";
    this.SubjectList = function () {

        return $http.get(this.AppUrl + 'Subject/GetList');
    }
    this.ChkUserTestResult = function (Subject_Id, UserName) {
        return $http.get(this.AppUrl + 'Subject/GetLists?Subject_Id=' + Subject_Id + '&UserName=' + UserName);
    }


});


app.controller('UserHomeController', function ($scope, UserhomeService,$rootScope) {
   
    $scope.showHome = false;
    $scope.showView = true;
    $scope.showBack = true;
    $scope.isDisabled = true;
    $scope.showResult = true;
    $rootScope.init = function () {

        UserhomeService.SubjectList().then(function (success) {
            $scope.ProgramArray = success.data;
        });
       
    };
    $scope.ViewButton = function (Subject_Id) {
     
        UserhomeService.Subject_Id = Subject_Id;
        $scope.UserName = angular.fromJson(sessionStorage.getItem("app")).UserName;
        UserhomeService.ChkUserTestResult(UserhomeService.Subject_Id, $scope.UserName).then(function (success) {
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
        window.location.href = '#/Levels';
    };

    $scope.ClickBtn = function () {

        $scope.showView = false;
        $scope.showHome = false;
        window.location.href = '#/Result';
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