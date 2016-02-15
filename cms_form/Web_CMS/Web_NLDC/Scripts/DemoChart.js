
$(window).resize(function () {
    drawChart();
});

$(function () {
    drawChart();
});

function drawChart() {
    var bodyWidth = document.body.clientWidth;

    $('#dvTQPT').highcharts({
        chart: {
            width: bodyWidth
        },
        option: highchartsOptions,
        title: {
            text: 'Biểu đồ tương quan phụ tải ngày',
            style: {
                fontWeight: 'bold',
                fontSize: '2em !important;',
                fontFamily: 'Helvetica Neue'
            }
        },
        xAxis: [{
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'], //mảng ngày: Dữ liệu lấy từ server
            crosshair: true
        }],
        yAxis: [{ // Primary yAxis
            labels: {
                format: '{value}đ/kwh',
                style: {
                    color: Highcharts.getOptions().colors[1]
                }
            },
            title: {
                text: 'Giá thị trường',
                style: {
                    color: Highcharts.getOptions().colors[1]
                }
            },
            opposite: true

        }, { // Secondary yAxis
            gridLineWidth: 0,
            title: {
                text: 'Phụ tải',
                style: {
                    color: Highcharts.getOptions().colors[0]
                }
            },
            labels: {
                format: '{value} MW',
                style: {
                    color: Highcharts.getOptions().colors[0]
                }
            }
        }
        ],
        tooltip: {
            shared: true
        },
        legend: {
            layout: 'vertical',
            align: 'left',
            x: 80,
            verticalAlign: 'top',
            y: 55,
            floating: true,
            backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
        },
        series: [{
            name: 'Phụ tải',
            type: 'column',
            yAxis: 1,
            data: [49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4], //dữ liệu động phụ tải lấy từ server
            tooltip: {
                valueSuffix: ' MW'
            }

        },
        {
            name: 'Giá biên',
            type: 'spline',
            data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6], // dữ liệu động giá thị trường lấy từ server
            tooltip: {
                valueSuffix: ' đ/kwh'
            }
        }]
    });
}


//theme
Highcharts.theme = {
    colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
    chart: {
        backgroundColor: {
            linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
            stops: [
            [0, 'rgb(255, 255, 255)'],
            [1, 'rgb(240, 240, 255)']
         ]
        },
        borderWidth: 0,
        plotBackgroundColor: 'rgba(255, 255, 255, .9)',
        plotShadow: true,
        plotBorderWidth: 1
    },
    title: {
        style: {
            color: '#000',
            font: 'bold 24px "Helvetica Neue", Helvetica, Arial, sans-serif !important'
        }
    },
    subtitle: {
        style: {
            color: '#666666',
            font: 'bold 12px "Helvetica Neue", Helvetica, Arial, sans-serif'
        }
    },
    xAxis: {
        gridLineWidth: 1,
        lineColor: '#000',
        tickColor: '#000',
        labels: {
            style: {
                color: '#000',
                font: '11px "Helvetica Neue", Helvetica, Arial, sans-serif'
            }
        },
        title: {
            style: {
                color: '#333',
                fontWeight: 'bold',
                fontSize: '12px',
                fontFamily: '"Helvetica Neue", Helvetica, Arial, sans-serif'

            }
        }
    },
    yAxis: {
        minorTickInterval: 'auto',
        lineColor: '#000',
        lineWidth: 1,
        tickWidth: 1,
        tickColor: '#000',
        labels: {
            style: {
                color: '#000',
                font: '11px "Helvetica Neue", Helvetica, Arial, sans-serif'
            }
        },
        title: {
            style: {
                color: '#333',
                fontWeight: 'bold',
                fontSize: '12px',
                fontFamily: '"Helvetica Neue", Helvetica, Arial, sans-serif'
            }
        }
    },
    legend: {
        itemStyle: {
            font: '9pt "Helvetica Neue", Helvetica, Arial, sans-serif',
            color: 'black'

        },
        itemHoverStyle: {
            color: '#039'
        },
        itemHiddenStyle: {
            color: 'gray'
        }
    },
    labels: {
        style: {
            color: '#99b'
        }
    },

    navigation: {
        buttonOptions: {
            theme: {
                stroke: '#CCCCCC'
            }
        }
    },
    credits: {
        enabled: false
    }
};

var highchartsOptions = Highcharts.setOptions(Highcharts.theme);