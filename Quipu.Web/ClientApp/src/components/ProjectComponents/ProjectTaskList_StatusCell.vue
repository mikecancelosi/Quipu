<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <q-select :hide-dropdown-icon="!hover"
                  borderless
                  v-model="newstatus.value"
                  @update:model-value="updatetask()"
                  :options="allStatusDropdownOptions"
                  dense
                  emit-value>

            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        <div>
                            <q-icon name="o_check"
                                    size="16px"
                                    :style="{visibility: scope.opt.category == (newstatus.value?.value?.id)
                                                                                                                        ? 'visible'
                                                                                                                        : 'hidden'}" />
                            <q-badge rounded :color="scope.opt.value.color">
                                {{scope.opt.label}}
                            </q-badge>
                        </div>
                    </q-item-section>
                </q-item>
            </template>
            <template v-slot:selected>
                <q-badge rounded
                         :color="newstatus.value?.value?.color ?? 'primary'"
                         v-if="newstatus.value.label != null">
                    {{newstatus.value?.label ?? ''}}
                </q-badge>
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
    import {   useStore } from 'vuex'
    import { ref, reactive, computed} from 'vue'
    export default {
        name: "StatusCell",
        emits: ["update-task"],
        props: {
            statusid: {
                type: Number,
                default: 0,
            },
        },
        setup(props, { emit }) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const newstatus = reactive({});
            const store = useStore()
            const allStatusDropdownOptions = computed(() => store.getters.allStatusDropdownOptions).value;
            const newid = computed(() => newstatus.value.id ?? 0);
            newstatus.value = allStatusDropdownOptions.find(x => x.category === props.statusid) ?? {};

            const updatetask = () => {
                emit("update-task", newid.value);
                newstatus.value = allStatusDropdownOptions.find(x => x.category === newstatus.value.id);
            };

            return { hover, updatetask, showdropdown, newstatus, store, allStatusDropdownOptions }
        },
    }
</script>