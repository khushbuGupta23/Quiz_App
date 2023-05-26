
var app = angular.module('SignUpModule', []);
app.service('SignUpService', function ($http) {
    this.AddUser = function (obj) {
        return $http.post('/api/MangaeUser/CreateRecord', obj);
    };
    this.GetRoleByRoleId = function () {
        return $http.post('/api/RoleMaster/GetRoleById');
    };
});
    
app.controller("SignUpController", function ($scope, SignUpService , $http, $rootScope) {


    $scope.UserList = [];
    $scope.Role_Id = "1";
    $scope.user = {
        UserName: null,
        Role: null,
        Mobile_Number: null,
        Email: null,
        Password: null,
        createBy: 1,
        ModifiedBy: 2,
    };
    $scope.init = function () {
        $scope.user = {
            UserName: null,
            Role: null,
            Mobile_Number: null,
            Email: null,
            Password: null,
            createBy: 1,
        };
        SignUpService.GetRoleByRoleId().then(function (success) {
            $scope.Rolelist = success.data;
            console.log("RoleList", $scope.Rolelist);
        });

       
    }
    $scope.SignUp = function () {
        debugger;
        SignUpService.AddUser($scope.user).then(function (success) {
            $scope.ResData = success.data;
            swal($scope.ResData);
            $scope.init();
        })

    }



});