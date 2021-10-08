<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false"
         v-if="loaded">
        <q-btn icon="o_person_outline"
               round
               outline
               dense
               size="10px"
               v-if="hover &&
                     !showdropdown &&
                     newuser == null"
               @click="assignUserClicked()"
               :style="{ visibility: newuser.value.value.id === null
                                             ? 'visible'
                                             : 'collapse'}" />
        <q-select dense
                  v-model="newuser.value"
                  :hide-dropdown-icon="!hover && !showdropdown"
                  :options="allUserDropdownOptions"
                  @update:model-value="updatetask()"
                  @popup-hide="showdropdown = false"
                  v-if="showdropdown ||  newuser.value != null"
                  borderless
                  emit-value>
            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        {{scope.opt.label}}
                    </q-item-section>
                </q-item>
            </template>

            <template v-slot:selected>
                {{newuser?.value?.label ?? ''}}
            </template>
        </q-select>


    </div>
</template>

<style scoped>
    .cell{
        width:100%;
        height:100%;
    }

</style>

<script>
    import { useStore } from 'vuex'
    import { ref, reactive, computed } from 'vue'

    export default {
        name: "AssigneeCell",
        emits: ["update-task"],
        props: {
            userid: {
                type: Number,
                default: 0,
            }
        },        
        setup(props, {emit }) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const newuser = reactive({});
            const loaded = ref(false);
            const store = useStore();
            const allUserDropdownOptions = computed(() => store.getters.allUserDropdownOptions).value;
            const newid = computed(() => newuser.value.id ?? 0);

            newuser.value = allUserDropdownOptions.find(x => x.category === props.userid);
            loaded.value = true;

            const updatetask = () => {
                emit("update-task", newid.value);
                newuser.value = allUserDropdownOptions.find(x => x.category === newuser.value.id);
            };

            return {
                hover, newid ,loaded, showdropdown, newuser, updatetask, allUserDropdownOptions
               
            }
        },

    }
</script>