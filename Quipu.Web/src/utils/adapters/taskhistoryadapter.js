export function adaptTaskRevision(revision) {
    var displayText = "EmptyDisplay";
    var userName = revision.user.displayName ?? "MIKE!";
    switch (revision.revisiontype) {
        case 'title':
            displayText = `${userName} changed the tasks title to ${revision.newvalue}`;
            break;
        case 'assignee':
            displayText = `${userName} assigned the task to ${revision.newvalue}`;
            break;
        case 'date':
            displayText = `${userName} changed the date to ${revision.newvalue}`;
            break;
        case 'priority':
            displayText = `${userName} changed the priority to ${revision.newvalue}`;
            break;
        case 'status':
            displayText = `${userName} changed the status to ${revision.newvalue}`;
            break;
        case 'description':
            displayText = `${userName} updated the description`;
            break;
        case 'subtask':
            displayText = `${userName} added a new subtask.`;
            break;
        case 'create':
            displayText = `${userName} created this task.`;
            break;

        default:
            break;
    }
    return {
        date: revision.date,
        user: revision.user,
        type: 'revision',
        display: displayText,
    };
}
