let pieChart = null;

const categoryMap = {
    0: "Food",
    1: "Transport",
    2: "Bills",
    3: "Entertainment",
    4: "Health",
    5: "Education",
    6: "Income",
    7: "Transfer"
};

async function loadTransactionPie() {
    try {
        // Fetch all transactions
        const response = await fetch('/api/transactions');
        const transactions = await response.json();
        
        // Aggregate by category
        const aggregated = {};
        transactions.forEach(t => {
            const categoryName = categoryMap[t.category] || "Unknown";
            if (!aggregated[categoryName]) {
                aggregated[categoryName] = 0;
            }
            aggregated[categoryName] += t.amount;
        });
        
        const categories = Object.keys(aggregated);
        const amounts = Object.values(aggregated);
        
        // Create or update chart
        createPieChart(categories, amounts);
    } catch (error) {
        console.error('Error loading transactions:', error);
        // Fallback to dummy data if API fails
        createPieChart(["Food", "Transport", "Bills", "Shopping"], [200, 80, 500, 150]);
    }
}

function createPieChart(categories, amounts) {
    const ctx = document.getElementById('spendingPieChart');
    
    if (pieChart) {
        pieChart.destroy(); // Destroy old chart if it exists
    }
    
    pieChart = new Chart(ctx, {
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
                    text: 'Transactions by Category',
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
}

// Load chart when DOM is ready
document.addEventListener('DOMContentLoaded', loadTransactionPie);