'use strict';

module.exports = function(grunt){
    grunt.initConfig({
        uglify: {
            src:{
                files: {
                    "src/scripts/concat.min.js": "src/scripts/concat.js"
                }
            }
        },
        concat: {
            options: {
                separator: ';'
            },
            js: {
                src: [
                    'bower_components/angular*/*.min.js',
                    'src/scripts/*.js',
                    '!src/scripts/concat.js',
                    '!src/scripts/concat.min.js'
                ],
                dest: 'src/scripts/concat.js'
            },
            css:{
                src: [
                    'src/css/*.css',
                    '!src/css/concat.css'
                ],
                dest: 'src/css/concat.css'
            }
        },
        watch: {
            scripts:{
                files: ['src/**/*.js'],
                tasks: ['concat:js', 'uglify'],
                options: {
                    spawn: false
                }
            },
            css:{
                files: ['src/**/*.less'],
                tasks: ['less', 'concat:css'],
                options: {
                    spawn: false
                }
            }
        },
        less: {
            dev:{
                options:{
                    paths: ['src/less', 'bower_components/bootstrap/less'],
                    cleancss: true
                },
                files: {
                    'src/css/app.css': 'src/less/app.less'
                }
            }
        }

    });

    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask('default', ['less', 'concat', 'uglify', 'watch']);
};