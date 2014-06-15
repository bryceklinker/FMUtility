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
            js: {
                src: [
                    'bower_components/angular/angular.js',
                    'bower_components/angular-route/angular-route.js',
                    'bower_components/angular-loader/angular-loader.js',
                    'bower_components/angular-bootstrap-ui/accordion/accordion.js',
                    'bower_components/angular-bootstrap-ui/alert/alert.js',
                    'bower_components/angular-bootstrap-ui/bindHtml/bindHtml.js',
                    'bower_components/angular-bootstrap-ui/buttons/buttons.js',
                    'bower_components/angular-bootstrap-ui/carousel/carousel.js',
                    'bower_components/angular-bootstrap-ui/collapse/collapse.js',
                    'bower_components/angular-bootstrap-ui/dateparser/dateparser.js',
                    'bower_components/angular-bootstrap-ui/datepicker/datepicker.js',
                    'bower_components/angular-bootstrap-ui/dropdown/dropdown.js',
                    'bower_components/angular-bootstrap-ui/modal/modal.js',
                    'bower_components/angular-bootstrap-ui/pagination/pagination.js',
                    'bower_components/angular-bootstrap-ui/popover/popover.js',
                    'bower_components/angular-bootstrap-ui/position/position.js',
                    'bower_components/angular-bootstrap-ui/progressbar/progressbar.js',
                    'bower_components/angular-bootstrap-ui/rating/rating.js',
                    'bower_components/angular-bootstrap-ui/tabs/tabs.js',
                    'bower_components/angular-bootstrap-ui/timepicker/timepicker.js',
                    'bower_components/angular-bootstrap-ui/tooltip/tooltip.js',
                    'bower_components/angular-bootstrap-ui/transition/transition.js',
                    'bower_components/angular-bootstrap-ui/typeahead/typeahead.js',
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
                files: ['src/scripts/*.js', '!src/scripts/concat.js', '!src/scripts/concat.min.js'],
                tasks: ['concat:js', 'uglify'],
                options: {
                    spawn: false
                }
            },
            css:{
                files: ['src/less/*.less'],
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