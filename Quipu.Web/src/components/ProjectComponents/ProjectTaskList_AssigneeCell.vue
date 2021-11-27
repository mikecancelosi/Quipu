<template>
  <div
    class="cell"
    @mouseenter="hover = true"
    @mouseleave="hover = false"
    v-if="loaded"
  >
    <q-select
      id="selectitem"
      dense
      v-model="newuser.value"
      :hide-dropdown-icon="!hover"
      :options="allUserDropdownOptions"
      @update:model-value="updatetask()"
      borderless
      emit-value
    >
      <template v-slot:option="scope">
        <q-item v-bind="scope.itemProps">
          <q-item-section>
            {{ scope.opt.label }}
          </q-item-section>
        </q-item>
      </template>

      <template v-slot:selected>
        {{ newuser?.value?.label ?? "" }}
      </template>
    </q-select>
  </div>
</template>

<style scoped>
.cell {
  width: 100%;
  height: 100%;
}
</style>

<script>
import { useStore } from "vuex";
import { ref, reactive, computed, toRefs,watch } from "vue";

export default {
  name: "AssigneeCell",
  emits: ["update-task"],
  props: {
    userid: {
      type: Number,
      default: 0,
    },
  },
  setup(props, { emit }) {
    const hover = ref(false);   
    const loaded = ref(false);
    const store = useStore();
    const allUserDropdownOptions = computed(
      () => store.getters.allUserDropdownOptions
    ).value;
    const newid = computed(() => newuser.value.id ?? 0);
    const newuser = reactive({});

    // Ensure newuser gets set properly when props update.
    const useridRef = toRefs(props).userid;       
    watch(useridRef, () => {
      setUserValue();
    })    
    const setUserValue = () => {
        newuser.value = allUserDropdownOptions.find(
      (x) => x.category === useridRef.value);
    }
    setUserValue();

    loaded.value = true;
    const updatetask = () => {
      emit("update-task", newid.value);
      newuser.value = allUserDropdownOptions.find(
        (x) => x.category === newuser.value.id
      );
    };

    return {
      hover,
      newid,
      loaded,
      newuser,
      updatetask,
      allUserDropdownOptions,
      setUserValue
    };
  },
};
</script>
