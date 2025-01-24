document.addEventListener("DOMContentLoaded", () => {
    const eventCategorySelect = document.getElementById("event-category");
    const addEventButton = document.getElementById("add-event-button");
    const dynamicForm = document.getElementById("dynamic-form");
    const eventList = document.getElementById("event-list");

    // When "Add Event" button is clicked
    addEventButton.addEventListener("click", () => {
        const selectedCategory = eventCategorySelect.value;

        // Clear the form before adding new fields
        dynamicForm.innerHTML = "";

        // Add dynamic form fields based on selected category
        if (selectedCategory === "transportation") {
            dynamicForm.innerHTML = `
        <h3>Transportation Details</h3>
        <label for="transport-mode">Mode of Transport:</label>
        <select id="transport-mode">
          <option value="bike">Bike</option>
          <option value="walk">Walk</option>
          <option value="bus">Bus</option>
          <option value="airplane">Airplane</option>
          <option value="car">Car</option>
        </select>

        <label for="transport-destination">Destination:</label>
        <input type="text" id="transport-destination" placeholder="Enter destination">

        <label for="transport-date">Date:</label>
        <input type="date" id="transport-date">

        <button type="button" id="save-transport">Save Transportation</button>
      `;

            document
                .getElementById("save-transport")
                .addEventListener("click", saveTransportation);
        } else if (selectedCategory === "hotel") {
            dynamicForm.innerHTML = `
        <h3>Hotel Details</h3>
        <label for="hotel-name">Hotel Name:</label>
        <input type="text" id="hotel-name" placeholder="Enter hotel name">

        <label for="hotel-rooms">Number of Bedrooms:</label>
        <input type="number" id="hotel-rooms" min="1">

        <label for="hotel-people">Number of People:</label>
        <input type="number" id="hotel-people" min="1">

        <button type="button" id="save-hotel">Save Hotel</button>
      `;

            document.getElementById("save-hotel").addEventListener("click", saveHotel);
        } else if (selectedCategory === "event") {
            dynamicForm.innerHTML = `
        <h3>Event Details</h3>
        <label for="event-name">Event Name:</label>
        <input type="text" id="event-name" placeholder="Enter event name">

        <label for="event-description">Event Description:</label>
        <textarea id="event-description" placeholder="Describe the event"></textarea>

        <button type="button" id="save-event">Save Event</button>
      `;

            document.getElementById("save-event").addEventListener("click", saveEvent);
        }
    });

    // Save Transportation
    function saveTransportation() {
        const mode = document.getElementById("transport-mode").value;
        const destination = document.getElementById("transport-destination").value;
        const date = document.getElementById("transport-date").value;

        if (!destination || !date) {
            alert("Please fill in all transportation details!");
            return;
        }

        addEventToList(`Transportation via ${mode} to ${destination} on ${date}`);
    }

    // Save Hotel
    function saveHotel() {
        const name = document.getElementById("hotel-name").value;
        const rooms = document.getElementById("hotel-rooms").value;
        const people = document.getElementById("hotel-people").value;

        if (!name || !rooms || !people) {
            alert("Please fill in all hotel details!");
            return;
        }

        addEventToList(`Hotel: ${name}, ${rooms} rooms for ${people} people.`);
    }

    // Save Event
    function saveEvent() {
        const name = document.getElementById("event-name").value;
        const description = document.getElementById("event-description").value;

        if (!name || !description) {
            alert("Please fill in all event details!");
            return;
        }

        addEventToList(`Event: ${name} - ${description}`);
    }

    // Utility: Add an event to the list
    function addEventToList(description) {
        if (eventList.children[0] && eventList.children[0].innerText === "No events added yet.") {
            eventList.children[0].remove();
        }

        const newEventItem = document.createElement("li");
        newEventItem.textContent = description;
        eventList.appendChild(newEventItem);

        dynamicForm.innerHTML = ""; // Clear the form after saving
    }
});
