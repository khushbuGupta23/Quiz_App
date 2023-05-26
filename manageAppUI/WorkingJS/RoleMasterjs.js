
var app = angular.module("roleModule", []);




app.service('AppService', function ($http) {
    //Get Record
    this.List = function () {
        return $http.get('/api/RoleMaster/GetList');
    };
    //Insert Record
	this.Input = function (obj) {
		return $http.post('/api/RoleMaster/ADDRole', obj);
    }
    //update Record
    this.updateRole = function (obj) {
        return $http.put('/api/RoleMaster/UpdateRole', obj);
    }

});

app.controller("appController", function ($scope, AppService, $http) {
    $scope.RoleId = 0;
    $scope.RoleList = [];
    $scope.ShowAdd = false;
    $scope.ShowDetail = false;
   
    $scope.submissionCompleted = false;
 


    $scope.role = {
        RoleName: null,
        Desiganation: null,
        Mobile_Number: null,
        Eamil: null,
        Password: null,
        createBy: 1,
        ModifiedBy:2,
    };
    $scope.init = function () {
        $scope.submissionCompleted = false;
        $scope.ShowAdd = true;
        $scope.role = {
            Role: null,
            CreatedBy: 1,
            ModifiedBy: 2,
        };
        
          //GetList
        AppService.List().then(function (response) {
            console.log("res", response);
                if(response.data.length > 0){
                    $scope.ShowDetail = true;
                $scope.RoleList = response.data;
            }
                else {
                    swal.fire("No Data");
            }
            
        })
        console.log("rolename", $scope.role.RoleName);
    }

    //Insert
    $scope.Input = function () {
        AppService.Input($scope.role).then(function (success) {
            $scope.ResData = success.data;

            swal($scope.ResData);
            
                $scope.init();
            })
        $scope.init();
    }

    //update by Appservice
    $scope.updateRole = function () {
        
        
        AppService.updateRole($scope.role).then(function (res) {
            
            $scope.RoleList = res.data;
            swal($scope.RoleList);
            $scope.init();
        });
    }

    //insert validation .. inputFn(role.Role)
   $scope.inputFn = function (event) {
        var rName = $scope.role.Role;
       // var rName = event.target.value;
        angular.forEach($scope.RoleList, function (value, key) {
            if (rName == value['Role']) {
                $scope.role.Role = "";
                swal(" role name is duplicate. please change role name.");
            }
        })
    }

    //Update
    
    $scope.updatedata = function (role) {
        $scope.ShowAdd = false;
        $scope.role = role;
    };
    $scope.BackBtn = function () {
        window.location.href = "#/Role/";
    };
 
    
    /*$scope.updateRole = function () {
        $http({
            method: "PUT",
            url: "/api/RoleMaster/UpdateRole",
            data: $scope.role
        }).then(function (res) {
            $scope.init();
            console.log(res.data);
            $scope.RoleList = res;
            swal(res.data, $scope.RoleList);
                console.log("res", res);
            
     
        });
        
    };*/

          //delete
    $scope.DeleteEmp = function (Role_Id) {
        console.log(Role_Id);


        Swal.fire({
            title: 'Are you sure to delete?',
            showDenyButton: true,
        }).then((result) => {
            if (result.isConfirmed) {
               
                $http({
                    method: "Delete",
                    url: "/api/RoleMaster/RemoveRole?Role_Id=" + Role_Id,
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

    $scope.init();
    $scope.Back = function () {
        window.location.href = '/index.html';
    };

});