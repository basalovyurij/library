(function () {
    'use strict';

    angular
        .module('app')
        .controller('AuthorListController', AuthorListController);

    AuthorListController.$inject = ['$scope', 'Author'];

    function AuthorListController($scope, Author) {
        $scope.authors = Author.query();
    }
})();