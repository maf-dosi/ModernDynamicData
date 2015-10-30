module.exports = function () {
    var project = require("./project.json");
    var bowerProperties = { "directory": "bower_components/" };
    var extensions = {
        js: ".min*.{js,map}",
        css: ".css"
    };
    var bowerFolder = bowerProperties.directory;
    var bootstrapFolder = bowerFolder + "bootstrap/";
    var bootstrapLessFolder = bootstrapFolder + "less/";
    var bootstrapDistFolder = bootstrapFolder + "dist/";
    var bootstrapFontsFolder = bootstrapFolder + "fonts/";
    var bootstrapJavascriptFolder = bootstrapDistFolder + "js/";

    var paths = {
        input: {
            bower: {
                config: "bower.json",
                folder: bowerFolder
            },
            sources: {
                less: {
                    all: "Styles/**/*.less",
                    folder: "Styles/",
                    site: "Styles/site.less",
                    variables: "Styles/variables.less"
                },
                typescripts: {
                    all: "Scripts/**/*.ts"
                }
            },
            librairies: {
                bootstrap: {
                    files: {
                        fonts: bootstrapFontsFolder + "glyphicons-halflings-regular.*",
                        javascript: bootstrapJavascriptFolder + "bootstrap*.js",
                        mainLess: bootstrapLessFolder + "bootstrap.less"
                    },
                    folders: {
                        fonts: bootstrapFontsFolder,
                        less: bootstrapLessFolder,
                        root: bootstrapFolder
                    }
                },
                jquery: {
                    files: {
                        javascript: bowerFolder + "jquery/dist/*.*"
                    }
                },
                typescriptDefinitions: {
                    all: "typings/**/*.d.ts"
                }
            },
            tsd: {
                config: "tsd.json"
            }
        },
        output: {
            fonts: {
                folder: "./" + project.webroot + "/fonts/"
            },
            scripts: {
                fileName: "app.js",
                folder: "./" + project.webroot + "/scripts/"
            },
            styles: {
                folder: "./" + project.webroot + "/styles/"
            }
        }
    };

    var config = {
        paths: paths,
        autoPrefixer: {
            browsers: ["last 2 version", "> 5%"]
        },
        lessCompiler: {
            paths: [].concat(
                paths.input.sources.less.folder,
                paths.input.librairies.bootstrap.folders.less)
        },
        tsdRestore: {
            command: "reinstall",
            config: "./" + paths.input.tsd.config,
            latest: false
        },
        typescriptCompiler: {
            declarationFiles: true,
            noExternalResolve: true
        }
    };
    return config;
}