
var app = angular.module("UserModule",[]);
app.service('UserService', function ($http){
    //getrecord
    this.GetUser = function () {
        return $http.get('/api/MangaeUser/GetList');
    };

    //insertRecord
    this.SetUser = function (obj) {
        return $http.post('/api/MangaeUser/CreateRecord', obj);
    };

    //UpdateRecord
    this.UpdateUser = function (obj) {
        return $http.post('/api/MangaeUser/UpdateUsers', obj);
    };

   
    //getbyID Record
   this.GetRoleByRoleId = function () {
   return $http.post('/api/RoleMaster/GetRoleById');
    };
    



});
app.controller("UserController", function ($scope, UserService, $http, $rootScope) {
    $scope.User_Id = 0;
    $scope.ShowDetail = false;
    $scope.ShowAdd = false;
    $scope.UserList = [];
    $scope.submissionCompleted = false;
    $scope.Role_Id = "1";

   $scope.user = {
        UserName: null,
       Role_Id: null,
        RoleName:null,
       Password: null,

        createBy: 1,
        ModifiedBy: 2,
    };
    $scope.init = function () {
        $scope.submissionCompleted = false;
        $scope.user = {
            UserName: null,
            Role: null,
            Mobile_Number: null,
            Email: null,
            Password: null,
            createBy: 1,
        };
        UserService.GetRoleByRoleId().then(function (success) {
            //debugger;
            $scope.Rolelist = success.data;
            $scope.ShowAdd = true;
            console.log("RoleList", $scope.Rolelist);
        });

        //GetList
        UserService.GetUser().then(function (response) {
            console.log("res", response);
            if (response.data.length > 0) {
                $scope.ShowDetail = true;
                $scope.ShowAdd = true;
                $scope.UserList = response.data;
                console.log('UserList', $scope.UserList);
            } else {
                swal("No Records !");
            }
        });
        console.log("Username", $scope.user.UserName);

    }

  

    //Insert
    $scope.SetUser = function () {
        UserService.SetUser($scope.user).then(function (success) {
            $scope.ResData = success.data;
            swal($scope.ResData );
            $scope.init();
        })

    }


    //update by Appservice
    $scope.UpdateUser = function () {
        UserService.UpdateUser($scope.user).then(function (res) {
            debugger;
            $scope.UserList = res.data;
            swal($scope.UserList);
            $scope.init();
        });
    }

    //Update
    $scope.updatedata = function (user) {
        $scope.ShowAdd = false;
        $scope.user = user;
    };
    //delete
    $scope.DeleteUser = function (UserId) {
        console.log(UserId);
        Swal.fire({
            title: 'Are you sure to delete?',
            showDenyButton: true,
        }).then((result) => {
            if (result.isConfirmed) {

                $http({
                    method: "Delete",
                    url: "/api/MangaeUser/Deleteuser?User_Id=" + UserId,
                }).then(function (res) {
                    new Swal("Deleted Successfully");

                    $scope.init();
                });
            }
            else if (result.isDenied) {
                Swal.fire('Delete Cancelled')
            }
        });
    }


    $scope.Back = function () {
        window.location.href = '/index.html';
    };


});