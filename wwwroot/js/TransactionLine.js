const monthLabels = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
new Chart(document.getElementById("spendingLineChart"), {
    type: "line",
    data: {
        labels: monthLabels,
        datasets: [
            {
                label: "",
                data: [1200, 100, 500, 0, 0, 0, 0, 0, 0, 0, 0, 0]
            }
        ]
    },
    options: {
        responsive: false,
        scales: {
            y: {
                ticks: {
                    callback: function (value, index, ticks) {
                        let amount = value;
                        if (value >= 1000) {
                            amount = (value / 1000).toFixed(1) + 'k';
                        }
                        return 'Php ' + amount;
                    }
                }
            }
        },
        plugins: {
            title: {
                display: true,
                text: 'Transactions of year',
                font: {
                    size: 16,
                    weight: 'bold'
                }
            },
            legend: {
                display: false
            }
        }
    }
})