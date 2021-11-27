import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount } from "@vue/test-utils";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_AssigneeCell.vue";
import createStore from "app/src/store/index";
import { QSelect } from "quasar";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

var store;
beforeAll(async () => {
  store = createStore();
  await store.dispatch("fetchUsers");
});

describe("AssigneeCell", () => {
  let wrapper;

  beforeEach(() => {
    wrapper = mount(Cell, {
      quasar: {
        components: {
          QSelect,
        },
      },
      global: {
        plugins: [store],
      },
    });
  });

  it("renders", () => {
    expect(wrapper.exists()).toBeTruthy();
  });

  it("has options", () => {
    expect(wrapper.vm.allUserDropdownOptions.length).toBeGreaterThan(0);
  });

  it("displays no selection when applicable", () => {
    expect(wrapper.vm.userid).toBe(0);
    expect(wrapper.text()).not.toContain("Test User 1");
  });

  it("displays selection when applicable", async () => {
    await wrapper.setProps({ userid: 1 });
    expect(wrapper.vm.userid).toBe(1);
    expect(wrapper.text()).toContain("Test User 1");
  });

  it("displays icon on hoverover", async () => {
    wrapper.componentVM.hover = true;
    await wrapper.vm.$nextTick();
    const dropdownIcon = wrapper.find(".q-select__dropdown-icon");
    expect(dropdownIcon.exists()).toBeTruthy();
  });

  it("displays options", async () => {
    expect(1).toEqual(0);
  });

  it("emits a change event", () => {
    expect(1).toEqual(0);
  });

  it("allows clearing of value", () => {
    expect(1).toEqual(0);
  });
});
