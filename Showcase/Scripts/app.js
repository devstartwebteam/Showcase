var ViewModel = function () {
    var self = this;
    self.posts = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.getPostDetail = function (item) {
        ajaxHelper(postsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    var postsUri = '/api/postsasync/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllPosts() {
        ajaxHelper(postsUri, 'GET').done(function (data) {
            self.posts(data);
        });
    }

    self.newPost = {
        PostName: ko.observable(),
        PostContent: ko.observable(),
        ViewCount: ko.observable(),
        AuthorName: ko.observable()
    }

    self.addPost = function (formElement) {
        var post = {
            PostName: self.newPost.PostName(),
            PostContent: self.newPost.PostContent(),
            ViewCount: self.newPost.ViewCount(),
            AuthorName: self.newPost.AuthorName()
        };

        ajaxHelper(postsUri, 'POST', post).done(function (item) {
            self.posts.push(item);
        });
    }

    // Fetch the initial data.
    getAllPosts();
};

ko.applyBindings(new ViewModel());