const monthLabels = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
const chartElement = document.getElementById("spendingLineChart");

if (chartElement) {
    const year = new Date().getFullYear();

    const formatCurrencyTick = (value) => {
        let amount = value;
        if (value >= 1000000) {
            amount = (value / 1000000).toFixed(1) + 'M';
        } else if (value >= 1000) {
            amount = (value / 1000).toFixed(1) + 'k';
        }
        return 'Php ' + amount;
    };

    const computeMonthlyTotals = (transactions) => {
        const totals = Array(12).fill(0);
        transactions.forEach(t => {
            const rawDate = t.date || t.Date;
            if (!rawDate) return;
            const dateObj = new Date(rawDate);
            if (isNaN(dateObj)) return;
            if (dateObj.getFullYear() !== year) return;

            const rawAmount = (t.amount && typeof t.amount === 'object') ? t.amount.amount : t.amount;
            const amount = Number(rawAmount) || 0;
            totals[dateObj.getMonth()] += amount;
        });
        return totals;
    };

    fetch(`/api/transactions?year=${year}`)
        .then(response => response.json())
        .then(data => {
            const monthlyTotals = computeMonthlyTotals(data || []);
            new Chart(chartElement, {
                type: "line",
                data: {
                    labels: monthLabels,
                    datasets: [
                        {
                            label: `Transactions in ${year}`,
                            data: monthlyTotals,
                            fill: false,
                            borderColor: '#0d6efd',
                            tension: 0.25,
                            pointRadius: 3
                        }
                    ]
                },
                options: {
                    responsive: false,
                    scales: {
                        y: {
                            ticks: {
                                callback: (value) => formatCurrencyTick(value)
                            }
                        }
                    },
                    plugins: {
                        title: {
                            display: true,
                            text: `Transactions of year ${year}`,
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
            });
        })
        .catch(() => {
        });
}