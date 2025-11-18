const categories = ["Food", "Transport", "Bills", "Shopping"];
const amounts = [200, 80, 500, 150];

new Chart(document.getElementById('spendingPieChart'), {
    type: 'pie',
    data: {
        labels: categories,
        datasets: [{ data: amounts, borderWidth: 1 }]
    },
    options: {
        responsive: false, 
        maintainAspectRatio: false, 

        plugins: {
            title: {
                display: true,
                text: 'Transactions',
                font: {
                    size: 16,
                    weight: 'bold'
                }
            },
            legend: {
                position: 'left',    
                align: 'center',      
                labels: {
                    font: {
                        size: 8
                    },
                    boxWidth: 20,    
                }
            }
        }
    }
});