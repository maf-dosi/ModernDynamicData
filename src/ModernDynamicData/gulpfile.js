/// <binding AfterBuild='compileLess, compileTypescript, copy' Clean='clean' ProjectOpened='restore, onOpen' />
var gulp = require("gulp"),
    $ = require("gulp-load-plugins")({ lazy: true }),
    args = require("yargs").argv,
    del = require("del"),
    runSequence = require("run-sequence");
var LessPluginCleanCss = require("less-plugin-clean-css"),
    cleancss = new LessPluginCleanCss({ advanced: true });
var debug = args.debug || true;
var config = require("./gulpfile.config")();

var taskNames = {
    build: "build",
    cleanFonts: "clean:fonts",
    cleanScripts: "clean:scripts",
    cleanStyles: "clean:styles",
    clean: "clean",
    compileLess: "compile:less",
    compileTypescript: "compile:typescript",
    compile: "compile",
    copyFonts: "copy:fonts",
    copyScripts: "copy:scripts",
    copyStyles: "copy:styles",
    copy: "copy",
    onOpen: "onOpen",
    restoreTypescriptDefinitions: "restore:typescriptDefinitions",
    restoreBowerComponents: "restore:bowerComponents",
    restore: "restore"
};

gulp.task(taskNames.cleanFonts, function (done) {
    del([].concat(config.paths.output.fonts.folder), done);
});
gulp.task(taskNames.cleanScripts, function (done) {
    del([].concat(config.paths.output.scripts.folder), done);
});
gulp.task(taskNames.cleanStyles, function (done) {
    del([].concat(config.paths.output.styles.folder), done);
});
gulp.task(taskNames.clean, [taskNames.cleanFonts, taskNames.cleanScripts, taskNames.cleanStyles]);

gulp.task(taskNames.restoreTypescriptDefinitions, function (done) {
    $.tsd(config.tsdRestore, done);
});
gulp.task(taskNames.restoreBowerComponents, function () {
    return $.bower(config.paths.input.bower.folder);
});
gulp.task(taskNames.restore, [taskNames.restoreTypescriptDefinitions, taskNames.restoreBowerComponents]);

gulp.task(taskNames.compileLess, [taskNames.restoreBowerComponents], function () {
    return gulp.src([].concat(config.paths.input.sources.less.site))
        .pipe($.if(debug, $.print()))
        .pipe($.if(debug, $.plumber()))
        .pipe($.sourcemaps.init())
        .pipe($.less(config.lessCompiler))
        .pipe($.autoprefixer(config.autoPrefixer))
        .pipe($.if(!debug, $.minifyCss()))
        .pipe($.sourcemaps.write("."))
        .pipe(gulp.dest(config.paths.output.styles.folder));
});
gulp.task(taskNames.compileTypescript, [taskNames.restoreTypescriptDefinitions], function () {
    return gulp.src([config.paths.input.sources.typescripts.all, config.paths.input.librairies.typescriptDefinitions.all])
        .pipe($.if(debug, $.print()))
        .pipe($.if(debug, $.plumber()))
        .pipe($.sourcemaps.init())
        .pipe($.tslint())
        .pipe($.tslint.report("prose"))
        .pipe($.typescript(config.typescriptCompiler))
        .js.pipe($.if(!debug, $.uglify()))
        .pipe($.if(!debug, $.concat(config.paths.output.scripts.fileName)))
        .pipe($.sourcemaps.write("."))
        .pipe(gulp.dest(config.paths.output.scripts.folder));
});
gulp.task(taskNames.compile, [taskNames.compileLess, taskNames.compileTypescript]);

gulp.task(taskNames.copyFonts, [taskNames.restoreBowerComponents], function () {
    var fontFiles = [].concat(config.paths.input.librairies.bootstrap.files.fonts);
    return copyFiles(fontFiles, config.paths.output.fonts.folder);
});
gulp.task(taskNames.copyScripts, [taskNames.restoreBowerComponents], function () {
    var scriptFiles = [].concat(config.paths.input.librairies.jquery.files.javascript);
    return copyFiles(scriptFiles, config.paths.output.scripts.folder);
});
gulp.task(taskNames.copyStyles, [taskNames.restoreBowerComponents], function () {
    var styleFiles = [].concat();
    return copyFiles(styleFiles, config.paths.output.styles.folder);
});
gulp.task(taskNames.copy, [taskNames.copyFonts, taskNames.copyScripts, taskNames.copyStyles]);

gulp.task(taskNames.build, function (done) {
    runSequence(taskNames.clean,
                taskNames.restore,
                [taskNames.compile, taskNames.copy],
                done);
});

gulp.task(taskNames.onOpen, function () {
    $.watch([].concat(config.paths.input.bower.config), function () {
        gulp.start(taskNames.restoreBowerComponents, taskNames.copy, taskNames.compileLess);
    });
    $.watch([].concat(config.paths.input.tsd.config), function () {
        gulp.start(taskNames.restoreTypescriptDefinitions, taskNames.compileTypescript);
    });
    $.watch([config.paths.input.sources.typescripts.all], function () {
        gulp.start(taskNames.compileTypescript);
    });
    $.watch([config.paths.input.sources.less.all], function () {
        gulp.start(taskNames.compileLess);
    });
});

////////////////////
function log(msg) {
    if (typeof (msg) === "object") {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.magenta(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.magenta(msg));
    }
}
function copyFiles(files, outputFolder) {
    return gulp.src(files)
        .pipe($.if(debug, $.print()))
        .pipe(gulp.dest(outputFolder));
};
