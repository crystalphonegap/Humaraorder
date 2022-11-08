"use strict";
// Class definition
var KTMorrisChartsDemo1 = function () {
    // Private functions

    var demo1 = function () {
        // LINE CHART
        new Morris.Line({
            // ID of the element in which to draw the chart.
            element: 'kt_morris_1',
            // Chart data records -- each entry in this array corresponds to a point on
            // the chart.
            data: [{
                y: '2006',
                a: 100,
                b: 90
            },
            {
                y: '2007',
                a: 75,
                b: 65
            },
            {
                y: '2008',
                a: 50,
                b: 40
            },
            {
                y: '2009',
                a: 75,
                b: 65
            },
            {
                y: '2010',
                a: 50,
                b: 40
            },
            {
                y: '2011',
                a: 75,
                b: 65
            },
            {
                y: '2012',
                a: 100,
                b: 90
            }
            ],
            // The name of the data record attribute that contains x-values.
            xkey: 'y',
            // A list of names of data record attributes that contain y-values.
            ykeys: ['a', 'b'],
            // Labels for the ykeys -- will be displayed when you hover over the
            // chart.
            labels: ['Values A', 'Values B'],
            lineColors: ['#6e4ff5', '#f6aa33']
        });
    }

    return {
        // public functions
        init: function () {
            demo1();
        }
    };
}();

var KTMorrisChartsDemo2 = function () {
    // Private functions
    var demo2 = function () {
        // AREA CHART
        new Morris.Area({
            element: 'kt_morris_2',
            data: [{
                y: '2006',
                a: 100,
                b: 90
            },
            {
                y: '2007',
                a: 75,
                b: 65
            },
            {
                y: '2008',
                a: 50,
                b: 40
            },
            {
                y: '2009',
                a: 75,
                b: 65
            },
            {
                y: '2010',
                a: 50,
                b: 40
            },
            {
                y: '2011',
                a: 75,
                b: 65
            },
            {
                y: '2012',
                a: 100,
                b: 90
            }
            ],
            xkey: 'y',
            ykeys: ['a', 'b'],
            labels: ['Series A', 'Series B'],
            lineColors: ['#de1f78', '#c7d2e7'],
            pointFillColors: ['#fe3995', '#e6e9f0']
        });
    }

    return {
        // public functions
        init: function () {
            demo2();
        }
    };
}();

var KTMorrisChartsDemo3 = function () {
    // Private functions

    var demo3 = function () {
        // BAR CHART
        new Morris.Bar({
            element: 'kt_morris_3',
            data: [{
                y: '2006',
                a: 100,
                b: 90
            },
            {
                y: '2007',
                a: 75,
                b: 65
            },
            {
                y: '2008',
                a: 50,
                b: 40
            },
            {
                y: '2009',
                a: 75,
                b: 65
            },
            {
                y: '2010',
                a: 50,
                b: 40
            },
            {
                y: '2011',
                a: 75,
                b: 65
            },
            {
                y: '2012',
                a: 100,
                b: 90
            }
            ],
            xkey: 'y',
            ykeys: ['a', 'b'],
            labels: ['Series A', 'Series B'],
            barColors: ['#2abe81', '#24a5ff']
        });
    }

    return {
        // public functions
        init: function () {
            demo3();
        }
    };
}();

var KTMorrisChartsDemo4 = function () {
    // Private functions

    var demo4 = function () {
        // PIE CHART
        new Morris.Donut({
            element: 'kt_morris_4',
            data: [{
                label: "Download Sales",
                value: 12
            },
            {
                label: "In-Store Sales",
                value: 30
            },
            {
                label: "Mail-Order Sales",
                value: 20
            }
            ],
            colors: ['#593ae1', '#6e4ff5', '#9077fb']
        });
    }

    return {
        // public functions
        init: function () {
            demo4();
        }
    };
}();

var KTMorrisChartsDemo5 = function () {
    // Private functions

    var demo5 = function () {
        // BAR CHART
        new Morris.Bar({
            element: 'kt_morris_5',
            data: [{
                y: '2013',
                a: 100,
                b: 40
            },
            {
                y: '2014',
                a: 75,
                b: 30
            },
            {
                y: '2015',
                a: 50,
                b: 20
            },
            {
                y: '2016',
                a: 75,
                b: 23
            },
            {
                y: '2017',
                a: 50,
                b: 30
            },
            {
                y: '2018',
                a: 75,
                b: 35
            },
            {
                y: '2019',
                a: 100,
                b: 34
            }
            ],
            xkey: 'y',
            ykeys: ['a', 'b'],
            labels: ['Completed Orders', 'pending Orders'],
            barColors: ['#127b70', '#db1430']
        });
    }

    return {
        // public functions
        init: function () {
            demo5();
        }
    };
}();

var KTMorrisChartsDemo6 = function () {
    // Private functions

    var demo6 = function () {
        // BAR CHART
        new Morris.Bar({
            element: 'kt_morris_6',
            data: [{
                y: 'June',
                a: 100
            },
            {
                y: 'July',
                a: 75
            },
            {
                y: 'Aug',
                a: 50
            },
            {
                y: 'Sept',
                a: 75
            },
            {
                y: 'Oct',
                a: 50
            },
            {
                y: 'Nov',
                a: 75
            }
            ],
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Completed Orders'],
            barColors: ['#db1430']
        });
    }

    return {
        // public functions
        init: function () {
            demo6();
        }
    };
}();

var KTMorrisChartsDemo7 = function () {
    // Private functions

    var demo7 = function () {
        // BAR CHART
        new Morris.Bar({
            element: 'kt_morris_7',
            data: [{
                y: 'Hiranandani',
                a: 100
            },
            {
                y: 'Raj Construction',
                a: 75
            },
            {
                y: 'Jai Bhawani',
                a: 50
            },
            {
                    y: 'Dhanraj',
                    a:60
             },
             {
                    y: 'Tata Construction',
                    a: 40
                }
            ],
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Total Order Value'],
            barColors: ['#2abe81']
        });
    }

    return {
        // public functions
        init: function () {
            demo7();
        }
    };
}();

var KTMorrisChartsDemo8 = function () {
    // Private functions

    var demo8 = function () {
        // BAR CHART
        new Morris.Bar({
            element: 'kt_morris_8',
            data: [{
                y: 'Jul',
                a: 100
            },
            {
                y: 'Aug',
                a: 80
            },
            {
                y: 'Sep',
                a: 60
            },
            {
                y: 'Oct',
                a: 90
            },
            {
                y: 'Nov',
                a: 40
            },
            {
                y: 'Dec',
                a: 30
            }

            ],
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Total Order Value'],
            barColors: ['#007bff']
        });
    }

    return {
        // public functions
        init: function () {
            demo8();
        }
    };
}();

var KTMorrisChartsDemo9 = function () {
    // Private functions

    var demo9 = function () {
        // PIE CHART
        new Morris.Donut({
            element: 'kt_morris_9',
            data: [
            {
                label: "Credit Limit",
                value: 400000
            },
            {
                label: "Credit Balance",
                value: 250000
            }
            ],
            colors: ['#282a3c', '#127b70']
        });
    }

    return {
        // public functions
        init: function () {
            demo9();
        }
    };
}();


var KTMorrisChartsDemo10 = function () {
    // Private functions

    var demo10 = function () {
        // BAR CHART
        new Morris.Bar({
            element: 'kt_morris_10',
            data: [{
                y: 'Sun',
                a: 100,
                b: 90
            },
            {
                y: 'Mon',
                a: 75,
                b: 65
            },
            {
                y: 'Tues',
                a: 50,
                b: 40
            },
            {
                y: 'Wed',
                a: 75,
                b: 65
            },
            {
                y: 'Thurs',
                a: 50,
                b: 40
            },
            {
                y: 'Fri',
                a: 75,
                b: 65
            },
            {
                y: 'Sat',
                a: 100,
                b: 90
            }
            ],
            xkey: 'y',
            ykeys: ['a', 'b'],
            labels: ['Tickets Open', 'Tickets Closed'],
            barColors: ['#2abe81', '#24a5ff']
        });
    }

    return {
        // public functions
        init: function () {
            demo10();
        }
    };
}();

jQuery(document).ready(function () {
    KTMorrisChartsDemo1.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo2.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo3.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo4.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo5.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo6.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo7.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo8.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo9.init();
});
jQuery(document).ready(function () {
    KTMorrisChartsDemo10.init();
});