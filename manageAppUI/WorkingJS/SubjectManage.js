var app = angular.module("Subjectmodule", []);


app.service('SubjectService', function ($http, $location) {
   
    this.List = function () {
        return $http.get('api/Subject/GetList');
    };

    this.Add = function (obj) {
        return $http.post('api/Subject/AddSub', obj);
    }

    this.UpdateSubject = function (obj) {
        return $http.post('api/Subject/UpdateSub', obj);
    }

    this.DeleteSub = function (Subject_Id) {
        return $http.delete('api/Subject/DeleteSub?Subject_Id=' + Subject_Id);
    }

   

    
});

app.controller("SubjectController", function ($scope, $http, SubjectService, $rootScope) {

    $scope.ShowDetail = false;
    $scope.ShowEdit = false;
    $scope.ShowDelete == false;
    $scope.ShowAdd == false;
    $scope.ShowAddQ = false;

    $scope.submissionCompleted = false;
    $scope.subjectList = [];

    $scope.subject = {
        Subject_Id: null,
        SubjectName: null,
        SubjectMarks: null,
        Role_Id: $scope.roleId,
        TotalQues: null,
        createBy: $scope.roleId,
        CreationDate:null,
        ModifiedBy: $scope.roleId,
        ModifiedDate:null
    };

    $scope.init = function () {
        $scope.submissionCompleted = false;
        $scope.ShowAddQ = true;
        $scope.subject = {
            Subject_Id: null,
            SubjectName: null,
            SubjectMarks: null,
            TotalQues: null,
            CreatedBy: null,
            ModifiedBy: null,
            RoleName: null,
        };
        /*if (sessionStorage.getItem("app") != null) {*/
      
            $scope.role = angular.fromJson(sessionStorage.getItem("app")).Role;
        //}
        //else {
        //    $scope.roleId = 1;
        //}

        SubjectService.List().then(function (response) {
            console.log("res", response);

            $scope.role== "Admin" ? $scope.ShowEdit = true : $scope.ShowEdit = false;
            $scope.role == "Admin" ? $scope.ShowDelete = true : $scope.ShowDelete = false;
            $scope.role == "Admin" ? $scope.ShowAdd = true : $scope.ShowAdd = false;
            $scope.subjectList = response.data;
            console.log("subId",$scope.subjectList);
      
          
        });
       
    }
    $scope.SelectQuestion = function (Subject_Id) {
        SubjectService.Subject_Id = Subject_Id;
        window.location.href = '#/Question/';
        $scope.init();
    };
    
    $scope.Add = function () {
        SubjectService.Add($scope.subject).then(function (success) {
            $scope.ResData = success.data;
            swal($scope.ResData);
            console.log($scope.ResData);
            $scope.init();

        });
    }


    $scope.UpdateSubject = function () {
       
        SubjectService.UpdateSubject($scope.subject).then(function (success) {

            console.log(success.data);
            $scope.subjectList = success.data;
            swal($scope.subjectList);
            $scope.init();
        })
    }
    //Update
    $scope.updatedata = function (subject) {
        $scope.ShowAddQ = false;
        $scope.subject= subject;
    };
    $scope.BackBtn = function () {
        window.location.href = "#/Subject/";
    };

    $scope.DeleteSub = function (Subject_Id) {
        $scope.Subject_Id = Subject_Id;
        Swal.fire({
            title: 'Are you sure to delete?',
            showDenyButton: true,
        }).then((result) => {
            if (result.isConfirmed) {

                SubjectService.DeleteSub($scope.Subject_Id).then(function (success) {

                    console.log(success.data);
                    $scope.subjectList = success.data;

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
        window.location.href = '#/Login/';
    };

});
         
