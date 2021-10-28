export function adaptRevision(revision) {
    var displayText = "EmptyDisplay";
    var userName = revision.user.display_Name ?? "MIKE!";
    switch (revision.revisionType) {
        case 'Title':
            displayText = `${userName} changed the tasks title to ${revision.newValue}.`;
            break;
        case 'Assignee':
            displayText = `${userName} assigned the task to ${revision.newValue}.`;
            break;
        case 'Date':
            displayText = `${userName} changed the date to ${revision.newValue}.`;
            break;
        case 'Priority':
            displayText = `${userName} changed the priority to ${revision.newValue}.`;
            break;
        case 'Status':
            displayText = `${userName} changed the status to ${revision.newValue}.`;
            break;
        case 'Description':
            displayText = `${userName} updated the description.`;
            break;
        case 'Subtask':
            displayText = `${userName} added a new subtask.`;
            break;
        case 'Create':
            displayText = `${userName} created this task.`;
            break;

        default:
            break;
    }
    return {
        date: revision.date,
        user: revision.user,
        type: revision.revisionType,
        display: displayText,
    };
}

export function adaptDiscussion(discussion) {
    return {
        date: discussion.date_Posted,
        user: discussion.user,
        type: 'Discussion',
        display: discussion.message_Contents,
    };
}