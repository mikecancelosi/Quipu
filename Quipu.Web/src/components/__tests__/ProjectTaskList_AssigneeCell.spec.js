import { mount } from "@cypress/vue";
import Cell from "../ProjectComponents/ProjectTaskList_AssigneeCell.vue";
import createStore from "app/src/store/index";

var store;
before(async () => {
  store = createStore();
  await store.dispatch("fetchUsers");
});

describe("AssigneeCell", () => {
  it("renders", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    cy.dataCy("select").should("be.visible");
  });

  it("displays initial selection when applicable", () => {
    mount(Cell, {
      props: {
        userid: 1,
      },
      global: {
        plugins: [store],
      },
    });
    cy.dataCy("select").should("contain", "Test User 1");
  });

  it("displays no initial selection when applicable", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    cy.dataCy("select").should("not.contain", "Test User 1");
  });

  it("hides dropdown button by default", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.get("q-select__dropdown-icon").should("not.exist");
  });

  it("shows dropdown on hover", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.dataCy("select").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").should("be.visible");
  });

  it("displays options", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.dataCy("select").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").click();
    cy.contains("Test User 2");
  });

  it("emits a change event", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    cy.dataCy("select").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").click();
    cy.get(".q-item")
      .first()
      .click()
      .should(() => {
        expect(Cypress.vueWrapper.emitted("update-task")).to.have.length(1);
      });
  });

  it("updates display value on selection", () => {
    mount(Cell, {
      global: {
        plugins: [store],
      },
    });

    cy.dataCy("select").trigger("mouseenter");
    cy.get(".q-select__dropdown-icon").click();
    cy.get(".q-item").first().click();
    cy.contains("Test");
  });
});
