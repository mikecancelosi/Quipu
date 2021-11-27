import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount } from "@vue/test-utils";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_NameCell.vue";
import createStore from "app/src/store/index";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

var store;
beforeAll(async () => {
  store = createStore();
  await store.dispatch("fetchUsers");
});

describe("NameCell", () => {
  let wrapper;

  beforeEach(() => {
    wrapper = mount(Cell, {
      global: {
        plugins: [store],
      },
    });
  });

  it("renders", () => {
    expect(wrapper.exists()).toBeTruthy();
  });

  it("Shows name value", () => {
    expect(1).toEqual(0);
  });

  it("Allows name edit", () => {
    expect(1).toEqual(0);
  });

  it("emits clear event", () => {
    expect(1).toEqual(0);
  });

  it("Displays unchecked when applicable", () => {
    expect(1).toEqual(0);
  });

  it("Displays checked when applicable", () => {
    expect(1).toEqual(0);
  });

  it("Allows checking", () => {
    expect(1).toEqual(0);
  });

  it("Allows unchecking", () => {
    expect(1).toEqual(0);
  });

  it("emits detail event ", () => {
    expect(1).toEqual(0);
  });
});
