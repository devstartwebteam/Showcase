$(document).on("submit", "#ds-comment-form", function (e) {
    e.preventDefault();
    if (DynamicValidation) {
        var form = $("#ds-comment-form");

        $.ajax({
                method: "POST",
                url: createCommentUrl,
                data: form.serialize()
            })
            .done(function() {
                SetList();
            });
    }
});

$(document).on("click", ".ds-reply-link", function() {
    $.ajax({
            method: "GET",
            url: newReplyUrl,
        })
        .done(function () {
            SetReply();
        });
});

function DynamicValidation() {
    if ($("#ds-comment-form").length > 0) {
        var $commentForm = $("#ds-comment-form");
        $.validator.unobtrusive.parse($commentForm);

        if ($commentForm.valid()) {
            return true;
        } else {
            return false;
        }
    }
    else {
        return false;
    }
}

function SetReply() {

}

function SetList() {
    $.ajax({
            method: "GET",
            url: getCommentsUrl,
            cache: false
        })
        .done(function (data) {
            $("#ds-comment-list").html(data);
        });
}


/*
Knockout.js stuff
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
*/