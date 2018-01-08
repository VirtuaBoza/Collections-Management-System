/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require('rimraf');
var merge = require('merge-stream');

gulp.task("minify", function ()
{
    gulp.src("wwwroot/js/*.js")
        .pipe(uglify())
        .pipe(concat("coracorpcm.min.js"))
        .pipe(gulp.dest("wwwroot/dist"));
});

var deps = {
    "jquery": {
        "dist/*": "dist"
    },
    "jquery-validation": {
        "dist/*": "dist"
    },
    "jquery-validation-unobtrusive": {
        "*.js": ""
    },
    "bootstrap": {
        "dist/**/*": "dist"
    },
    "font-awesome": {
        "css/*": "css",
        "fonts/*": "fonts"
    }
};

gulp.task("clean", function (cb)
{
    return rimraf("wwwroot/lib/", cb);
});

gulp.task("scripts", function ()
{
    var streams = [];

    for (var prop in deps) {
        if (deps.hasOwnProperty(prop)) {
            console.log("Prepping Scripts for: " + prop);
            for (var itemProp in deps[prop])
            {
                if (deps[prop].hasOwnProperty(itemProp)) {
                    streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                        .pipe(gulp.dest("wwwroot/lib/" + prop + "/" + deps[prop][itemProp])));
                } else {
                    console.log("This does not exist: " + itemProp);
                }
            }
        } else {
            console.log("This does not exist: " + prop);
        }
    }

    return merge(streams);
});
