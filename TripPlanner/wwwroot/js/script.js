document.addEventListener('DOMContentLoaded', () => {
    const addEventButton = document.getElementById('add-event-button');
    const eventList = document.getElementById('event-list');

    addEventButton.addEventListener('click', () => {
        // Prompt user for event details
        const eventName = prompt("Enter the event name:");
        const eventTime = prompt("Enter the event time (e.g., 10:00 AM):");
        const eventDescription = prompt("Enter a brief description:");

        if (eventName && eventTime && eventDescription) {
            // Remove placeholder text if it exists
            const placeholder = eventList.querySelector('li');
            if (placeholder && placeholder.textContent === "No events added yet.") {
                placeholder.remove();
            }

            // Add the new event to the list
            const eventItem = document.createElement('li');
            eventItem.innerHTML = `<strong>${eventName}</strong> - ${eventTime}<br>${eventDescription}`;
            eventList.appendChild(eventItem);
        } else {
            alert("Please provide complete event details!");
        }
    });
});