var app = angular.module("QuestionModule", []);

app.service('QuestionService', function ($http, $location) {
    this.AppUrl = "";

    console.log($location.absUrl());

    if ($location.absUrl().indexOf('CST') != -1) {
        this.AppUrl = "/CST/api"
    }
    else {

        this.AppUrl = "/api"
    }
    this.GetQuestionList = function () {
        return $http.get(this.AppUrl + '/QuestionBank/GetQuestionList');
    };
    this.AddQuestion = function (data) {
        return $http.post(this.AppUrl + '/QuestionBank/AddQues', data, {});
    };
    this.UpdateQuestion = function (obj) {
        return $http.put(this.AppUrl + '/QuestionBank/UpdateQuestion', obj);
    }
    this.DeleteQuestion = function (Question_Id) {
        return $http.delete(this.AppUrl + '/QuestionBank/RemoveQuestion?Question_Id=' + Question_Id);
    };
    this.GetBySubjectId = function (Subject_Id) {
        return $http.post(this.AppUrl + '/QuestionBank/GetQuestionbySubject_Id?Subject_Id=' + Subject_Id);
    }


});
app.controller('QuestionBankController', function ($scope, $http, $rootScope, QuestionService, SubjectService) {
    $scope.ShowDeleteAllButton = true;
    $scope.ShowAdd = false;
    $scope.QuestionList = [];
    
    $scope.init = function () {
        $scope.ShowDeleteAllButton = true;
        $scope.ShowAdd = true;
        console.log(SubjectService.Subject_Id, "SubjectId");

        $scope.QuestionDetailData = {
            
            Question: null,
            Answer1: null,
            Answer2: null,
            Answer3: null,
            Answer4: null,
            AnswerKey: null,
            IsActive: true,
            Subject_Id:null,
            CreatedBy: $scope.roleId,
            CreationDate: null,
            ModifiedBy: $scope.roleId,
            ModifiedDate: null


        };
       
        QuestionService.GetBySubjectId(SubjectService.Subject_Id).then(function (response) {

            $scope.QuestionList = response.data;
            console.log("Questi", $scope.QuestionList)
        });

        //QuestionService.GetQuestionList().then(function (response) {
        //    console.log("res", response);
        //    $scope.QuestionList = response.data;
        //    //console.log('QuestionList', $scope.QuestionList);

        //});
    }
  
    $scope.AddQuestion = function () {
        
        console.log("sub", SubjectService.Subject_Id);
        $scope.QuestionDetailData.Subject_Id = SubjectService.Subject_Id;

        console.log("Question Detail Data", $scope.QuestionDetailData);

        QuestionService.AddQuestion($scope.QuestionDetailData).then(function (success) {
                    $scope.ResData = success.data;
            swal("Questions have been added sucessfully");
                    $scope.init();
                },
                    function (error) {
                        console.log(error.data);
                        swal( "error");
                    });
    }
    $scope.UpdateQuestion = function () {
        

        console.log("sub", SubjectService.Subject_Id);
        $scope.QuestionDetailData.Subject_Id = SubjectService.Subject_Id;
        QuestionService.UpdateQuestion($scope.QuestionDetailData).then(function (success) {
            $scope.ResData = success.data;
            swal("Updated Successfully");
            $scope.init();
        });
    }
    $scope.updatedata = function (QuestionDetailData) {
        $scope.ShowAdd = false;
        $scope.QuestionDetailData = QuestionDetailData;
    };

    
    $scope.DeleteQuestion = function (Question_Id) {
        //debugger;
        $scope.Question_Id = Question_Id;
        Swal.fire({
            title: 'Are you sure to delete?',
            showDenyButton: true,
        }).then((result) => {
            if (result.isConfirmed) {
            QuestionService.DeleteQuestion($scope.Question_Id).then(function success(data) {
            $scope.QuestionList = data;

                new Swal("Deleted Successfully");

                $scope.init();
            });
            }
            else if (result.isDenied) {
                Swal.fire('Delete Cancelled')
            }
        });

    };
    $scope.Back = function () {
        window.location.href = '#/Subject/';
    };

    $scope.init();
});