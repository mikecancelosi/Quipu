<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <q-select :hide-dropdown-icon="!hover"
                  borderless
                  v-model="newpriority"
                  @update:model-value="updatetask()"
                  :options="allPriorityDropdownOptions"
                  dense
                  emit-value>

            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        <div>
                            <q-icon name="o_check"
                                    size="16px"
                                    :style="{visibility: scope.opt.category == (newpriority.value?.value?.id ?? 0)
                                                                              ? 'visible'
                                                                              : 'hidden'}" />
                            <q-badge rounded 
                                     :color="scope.opt.value.color">
                                {{scope.opt.label}}
                            </q-badge>
                        </div>
                    </q-item-section>
                </q-item>
            </template>
            <template v-slot:selected>
                <q-badge rounded
                         :color="newpriority.value?.value?.color ?? 'primary'"
                         v-if="newpriority.value.label != null">
                    {{newpriority.value?.label ?? "" }}
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
    import { mapGetters, mapActions, useStore } from 'vuex'
    import { ref,reactive, computed } from 'vue'

    export default {
        name: "PriorityCell",
        emits: ["update-task"],
        computed: mapGetters(['allPriorityDropdownOptions']),
        created() {
            this.fetchPriorityTypes();
        },
        props: {
            priorityid: {
                type: Number,
                default: 0
            },
        },
        setup(props) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const newpriority = reactive({});
            const store = useStore()
            const allPriorityDropdownOptions = computed(() => store.getters.allPriorityDropdownOptions).value;
            
            newpriority.value = allPriorityDropdownOptions.find(x => x.category === props.priorityid) ?? {};
            console.log(newpriority.value.label);
            const updatetask = () => {
                this.$emit("update-task", this.newpriority);
            };          

            return { hover, showdropdown, newpriority, updatetask, allPriorityDropdownOptions}
        },
        methods: {
             ...mapActions(['fetchPriorityTypes']),
        },
    }
</script>