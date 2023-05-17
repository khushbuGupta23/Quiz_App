var module = angular.module('LoginModule', ['ngLoadingSpinner']);

module.service('LoginService', function ($http, $location) {
    this.ValidateUser = function (obj) {
        return $http.post('/api/Login/ValidateUser', obj);
    };

});


module.controller('LoginController', function ($scope,  LoginService, ) {

    $scope.ShowDetail = false;
    $scope.submissionCompleted = false;
    $scope.UserName = '';
    $scope.message = "";
    $scope.UserDetails = {
        UserName: null,
        Password: null,
      
    };

    $scope.init = function () {
        $scope.submissionCompleted = false;
        $scope.message = "";
        $scope.UserDetails = {
            UserName: null,
            Password: null,
           
        };
       
    }
    //Check Validation 
    
    $scope.Login = function () {
        console.log("Click");
        
        LoginService.ValidateUser($scope.UserDetails).then(function (success) {
            $scope.ResData = success.data;
            console.log('Data', $scope.ResData);
           
            if ($scope.ResData.IsSuccess == true) {
                sessionStorage.setItem("app", angular.toJson(success.data));
                console.log("User",sessionStorage);
                $scope.UserList = success.data;
                if ($scope.ResData.Role == 'Admin') {
                    window.location.href = '/index.html';

                }
                else {
                    window.location.href = '/UserHome.html';
                }
            }
            else {
               swal($scope.ResData.msg);
                return false;
            }

        });
    }
});