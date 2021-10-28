export function formatMMDD(input) {
    var newDate = new Date(input);
    return (
        newDate.getMonth() +
        "/" +
        newDate.getDate()
    );
};

export function formatMonthNameDD(input) {
    var newDate = new Date(input);
    const month = newDate.toLocaleString('default', { month: 'short' });
    return (
        month +
        " " +
        newDate.getDate()
    );
}